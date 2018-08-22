using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class OffCenterProjection : MonoBehaviour
{
    public GameObject virtualWindow;

    public float width;
    public float height;

    public float MaxHeight = 2000.0f;

    float windowHeight;
    float windowWidth;

    Camera cam;

    /**public float left = -0.2F;
    public float right = 0.2F;
    public float top = 0.2F;
    public float bottom = -0.2F;
    */

    private void Start()
    {
        cam = Camera.main;
    }
    void LateUpdate()
    {
        windowWidth = width;
        windowHeight = height;

        Vector3 localPos = virtualWindow.transform.InverseTransformPoint(transform.position);

        Vector3 newpos = localPos;
        float focal = 1f;
        newpos = new Vector3(newpos.x, newpos.y, newpos.z);
        focal = Mathf.Clamp(newpos.z, 0.001f, MaxHeight);

        float ratio = focal / cam.nearClipPlane;

        float imageLeft = (-windowWidth / 2.0f) + newpos.x;
        float imageRight = (windowWidth / 2.0f) + newpos.x;
        float imageTop = (windowHeight / 2.0f) - newpos.y;  
        float imageBottom = (-windowHeight / 2.0f) - newpos.y;
        float nearLeft = imageLeft / ratio;
        float nearRight = imageRight / ratio;
        float nearTop = imageTop / ratio;
        float nearBottom = imageBottom / ratio;



        Matrix4x4 m = PerspectiveOffCenter(nearLeft, nearRight, nearBottom, nearTop, cam.nearClipPlane, cam.farClipPlane);
        cam.projectionMatrix = m;
       // cam.transform.LookAt(transform.InverseTransformPoint(virtualWindow.transform.position));
    }

    static Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
    {
        float x = 2.0F * near / (right - left);
        float y = 2.0F * near / (top - bottom);
        float a = (right + left) / (right - left);
        float b = (top + bottom) / (top - bottom);
        float c = -(far + near) / (far - near);
        float d = -(2.0F * far * near) / (far - near);
        float e = -1.0F;
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = x;
        m[0, 1] = 0;
        m[0, 2] = a;
        m[0, 3] = 0;
        m[1, 0] = 0;
        m[1, 1] = y;
        m[1, 2] = b;
        m[1, 3] = 0;
        m[2, 0] = 0;
        m[2, 1] = 0;
        m[2, 2] = c;
        m[2, 3] = d;
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = e;
        m[3, 3] = 0;
        return m;
    }
}