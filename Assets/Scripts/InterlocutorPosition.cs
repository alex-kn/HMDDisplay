using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterlocutorPosition : MonoBehaviour {

    bool isAndroid = false;
    Vector3 origPosition;
    Vector3 pos;

    Transform target;
    float speed;

    AndroidJavaObject faceTracker;

    float phoneCameraOffsetX = 0f;
    float phoneCameraOffsetY = 0f;

	// Use this for initialization
	void Start () {
        Debug.Log("Starting InterlocutorPosition, checking for Android device");
        origPosition = transform.localPosition;
        
        isAndroid = Application.platform == RuntimePlatform.Android;
        speed = 30f;

        Debug.Log(origPosition);
        if(isAndroid)
        {
            Debug.Log("Android found.");

            AndroidJavaClass unitPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unitPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

            faceTracker = new AndroidJavaObject("ak.hmddisplay.mobilevision.HMDFaceTracker", activity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isAndroid)
        {
            float step = speed * Time.deltaTime;

            float[] query = faceTracker.Call<float[]>("query");
            //pos = new Vector3(query[0] * 0.02646f + phoneCameraOffsetX, -query[1] * 0.02646f + phoneCameraOffsetY, 0);
            //Vector3 newPosition = origPosition + pos;

            Vector3 rlCameraVec = new Vector3(query[0] / 100, -query[1] / 80, 0);
            Vector3 distPosition = rlCameraVec + origPosition;

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, distPosition, step);


            //if (distPosition != null || distPosition.Equals(new Vector3(0, 0, 0)))
            //{

                //Vector3 currentPosition = transform.localPosition;
                //float p = 0.05f;
                //transform.localPosition = currentPosition + (distPosition - currentPosition) * p;
            //}

            //transform.position = newPosition;
        }
    }
}
