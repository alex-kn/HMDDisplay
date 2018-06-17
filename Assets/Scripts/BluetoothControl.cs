using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles the Bluetooth communication to remotely control switching representations and cues.
 */
public class BluetoothControl : MonoBehaviour {

    AndroidJavaObject bluetoothController;

    public RepresentationController representationController;
    public CueClickController cueClickController;

    public delegate void ActivateCueDelegate(string code);
    public delegate void SwitchRepresentationDelegate();

    protected static readonly Queue<Action> taskQueue = new Queue<Action>();
    protected static object _queueLock = new object();


    // Use this for initialization
    void Start () {
        bool isAndroid = Application.platform == RuntimePlatform.Android;

        ActivateCueDelegate activateCueHandler = cueClickController.ActivateCue;
        SwitchRepresentationDelegate switchRepresentationHandler = representationController.SwitchRepresentation;

        if (isAndroid)
        {
            AndroidJavaClass unitPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unitPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            bluetoothController = new AndroidJavaObject("ak.hmddisplay.bluetoothconnect.BluetoothController", activity);
            bluetoothController.Call("addBluetoothListener", new CueCallback(activateCueHandler, switchRepresentationHandler));

            StartBluetooth();
        }
    }

    // Update is called once per frame
    void Update () {
        lock (_queueLock)
        {
            if (taskQueue.Count > 0)
            {
                taskQueue.Dequeue()();
            }
        }
	}


    private void StartBluetooth()
    {
        bluetoothController.Call("connectAsServer");
    }

    /**
     * Callback proxy implementing an interface in Java code to handle calls from Java to Unity
     */
    class CueCallback : AndroidJavaProxy
    {

        private ActivateCueDelegate cueCallback;
        private SwitchRepresentationDelegate repCallback;

        public CueCallback(ActivateCueDelegate cueCallback, SwitchRepresentationDelegate repCallback) : base("ak.hmddisplay.bluetoothconnect.OnMessageReceivedListener")
        {
            this.cueCallback = cueCallback;
            this.repCallback = repCallback;
        }

        /** 
         * Callback referenced in Java code to handle incoming messages
         * 
         * code denotes the action that is to be taken (switch representation, switch cues)
         */
        public void onMessageReceived(string code)
        {
            Debug.Log("Message Received: " + code);
            lock (_queueLock)
            {

                if (code.Equals("0"))
                {
                    taskQueue.Enqueue(() => repCallback());
                }
                else
                {
                    taskQueue.Enqueue(() => cueCallback(code));
                }
            }
        }
    }
}
