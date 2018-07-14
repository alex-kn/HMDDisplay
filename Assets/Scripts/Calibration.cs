using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * NOT USED
 */
public class Calibration : MonoBehaviour {

    public Button left;
    public Button right;
    public Button up;
    public Button down;

    public Camera cam;

    // Use this for initialization
    void Start() {
        left.onClick.AddListener(Left);
        right.onClick.AddListener(Right);
        up.onClick.AddListener(Up);
        down.onClick.AddListener(Down);
    }


    void Left()
    {
        cam.transform.Translate(Vector3.left);
    }

    void Right()
    {
        cam.transform.Translate(Vector3.right);

    }

    void Up()
    {
        cam.transform.Translate(Vector3.up);

    }
    void Down()
    {
        cam.transform.Translate(Vector3.down);

    }
}
