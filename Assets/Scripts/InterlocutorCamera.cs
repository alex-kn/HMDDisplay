using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterlocutorCamera : MonoBehaviour
{

    Camera camera;
    public GameObject obj;

    public int phoneCameraWidth = 640;
    public int phoneCameraHeight = 480;

    void Start()
    {
        camera = GetComponent<Camera>();

    }

    void Update()
    {
        Vector3 p = camera.ScreenToWorldPoint(new Vector3((640  / phoneCameraWidth) * camera.pixelWidth, (480 / phoneCameraHeight) * camera.pixelHeight, camera.nearClipPlane));
        float step = 10 * Time.deltaTime;
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, p, step);
    }
}
