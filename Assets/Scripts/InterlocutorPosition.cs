﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterlocutorPosition : MonoBehaviour
{

    bool isAndroid = false;
    Vector3 origPosition;

    //this is a dummy cam used to convert the 2D point from face tracking to a 3D point in the scene
    Camera phoneCam;

    Camera mainCam;

    public int phoneCameraWidth = 640;
    public int phoneCameraHeight = 480;

    public GameObject interlocPos;

    float[] lastPosition = new float[2];
    float speed;
    AndroidJavaObject faceTracker;

    // Use this for initialization
    void Start()
    {
        phoneCam = GetComponent<Camera>();
        mainCam = Camera.main;
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
            var tmp = faceTracker.Call<float[]>("query");
            if (tmp[0] == lastPosition[0] && tmp[1] == lastPosition[1])
            {
                return;
            }
            lastPosition = tmp;
            Vector3 p = phoneCam.ScreenToWorldPoint(new Vector3((lastPosition[0] / phoneCameraWidth) * phoneCam.pixelWidth, phoneCam.pixelHeight - (lastPosition[1] / phoneCameraHeight) * phoneCam.pixelHeight, phoneCam.nearClipPlane));
            float step = speed * Time.deltaTime;

            interlocPos.transform.position = Vector3.MoveTowards(interlocPos.transform.position, p, step);

           
        }
        else
        {
            //lastPosition = new float[] { 640, 480 };
        }
    }
}
