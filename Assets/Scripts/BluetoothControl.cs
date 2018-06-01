using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluetoothControl : MonoBehaviour {

    AndroidJavaObject bluetoothController;

    private CueClickController cueClickController;

	// Use this for initialization
	void Start () {
        bool isAndroid = Application.platform == RuntimePlatform.Android;
        cueClickController = GetComponent<CueClickController>();
        if (isAndroid)
        {
            Debug.Log("Android found.");

            AndroidJavaClass unitPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unitPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            Debug.Log("YAZ");
            bluetoothController = new AndroidJavaObject("ak.hmddisplay.bluetoothconnect.BluetoothController", activity);
           
                Debug.Log("YAY");
            
            bluetoothController.Call("addBluetoothListener", new CueCallback());

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
        public CueCallback() : base("ak.hmddisplay.bluetoothconnect.OnMessageReceivedListener") { }
        public void onMessageReceived(int code)
        {
            Debug.Log("Message Received");
            Debug.Log(code);
        }
    }
}
