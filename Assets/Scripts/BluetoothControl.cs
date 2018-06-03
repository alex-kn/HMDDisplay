using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluetoothControl : MonoBehaviour {

    AndroidJavaObject bluetoothController;

    public RepresentationController representationController;
    public CueClickController cueClickController;

    public delegate void ActivateCueDelegate(string code);

	// Use this for initialization
	void Start () {
        bool isAndroid = Application.platform == RuntimePlatform.Android;
        cueClickController = GetComponent<CueClickController>();

        ActivateCueDelegate activateCueHandler = cueClickController.ActivateCue;

        if (isAndroid)
        {
            Debug.Log("Android found.");

            AndroidJavaClass unitPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unitPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            bluetoothController = new AndroidJavaObject("ak.hmddisplay.bluetoothconnect.BluetoothController", activity);
            
            bluetoothController.Call("addBluetoothListener", new CueCallback(activateCueHandler));

            StartBluetooth();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}


    private void StartBluetooth()
    {
        bluetoothController.Call("connectAsServer");
    }

    class CueCallback : AndroidJavaProxy
    {

        private ActivateCueDelegate callback;
        public CueCallback(ActivateCueDelegate callback) : base("ak.hmddisplay.bluetoothconnect.OnMessageReceivedListener")
        {
            this.callback = callback;
        }
        public void onMessageReceived(string code)
        {
            Debug.Log("Message Received");
            Debug.Log(code);
            callback(code);
        }
    }
}
