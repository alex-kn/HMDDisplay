using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterlocutorCamera : MonoBehaviour
{

    Camera cam;
    public GameObject obj;

    public int phoneCameraWidth = 640;
    public int phoneCameraHeight = 480;

    void Start()
    {
        cam = GetComponent<Camera>();

    }

    void Update()
    {
        Vector3 p = cam.ScreenToWorldPoint(new Vector3((640  / phoneCameraWidth) * cam.pixelWidth, (480 / phoneCameraHeight) * cam.pixelHeight, cam.nearClipPlane));
        float step = 10 * Time.deltaTime;
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, p, step);
    }
}
