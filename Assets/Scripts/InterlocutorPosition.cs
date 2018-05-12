using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterlocutorPosition : MonoBehaviour
{

    bool isAndroid = false;
    Vector3 origPosition;

    Camera cam;
    public int phoneCameraWidth = 640;
    public int phoneCameraHeight = 480;

    public GameObject interlocPos;

    float[] lastPosition;
    float speed;
    AndroidJavaObject faceTracker;



    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
        Debug.Log("Starting InterlocutorPosition, checking for Android device");
        origPosition = transform.localPosition;

        isAndroid = Application.platform == RuntimePlatform.Android;
        speed = 1000f;


        Debug.Log(origPosition);
        if (isAndroid)
        {
            Debug.Log("Android found.");

            AndroidJavaClass unitPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unitPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

            faceTracker = new AndroidJavaObject("ak.hmddisplay.mobilevision.HMDFaceTracker", activity);
        }
    }

    void Update()
    {
        if (isAndroid)
        {
            lastPosition = faceTracker.Call<float[]>("query");
            Vector3 p = cam.ScreenToWorldPoint(new Vector3((lastPosition[0] / phoneCameraWidth) * cam.pixelWidth, cam.pixelHeight - (lastPosition[1] / phoneCameraHeight) * cam.pixelHeight, cam.nearClipPlane));
            float step = speed * Time.deltaTime;
            interlocPos.transform.position = Vector3.MoveTowards(interlocPos.transform.position, p, step);
        }
        else
        {
            //lastPosition = new float[] { 640, 480 };
        }
    }
}
