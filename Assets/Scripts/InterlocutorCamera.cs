using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterlocutorCamera : MonoBehaviour
{

    Camera cam;
    public GameObject phoneDisplay;
    private Plane plane;


    void Start()
    {
        cam = GetComponent<Camera>();
        //Instantiate<Plane>(new Plane(new Vector3(1,1), new Vector3(-1, 1), new Vector3(1,-1));
        plane = new Plane(new Vector3(1, 1, 0), new Vector3(-1, 1, 0), new Vector3(1, -1, 0 ));

    }

    void Update()
    {
        Debug.DrawRay(cam.transform.position - plane.normal * plane.GetDistanceToPoint(cam.transform.position), plane.normal * plane.GetDistanceToPoint(cam.transform.position), Color.red);

        Vector4 clipPlaneWorldSpace = new Vector4(plane.normal.x, plane.normal.y, plane.normal.z, Vector3.Distance(phoneDisplay.transform.position, transform.position));
        Vector4 clipPlaneCameraSpace = Matrix4x4.Transpose(cam.cameraToWorldMatrix) * clipPlaneWorldSpace;

        cam.projectionMatrix = cam.CalculateObliqueMatrix(clipPlaneWorldSpace);
        Debug.Log(cam.projectionMatrix);

        //cam.fieldOfView = 2.0f * Mathf.Atan(frustumHeight * 0.5f / distance) * Mathf.Rad2Deg;

    }
}
