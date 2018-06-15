using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixationPointMovement : MonoBehaviour {

    public GameObject interlocutorPosition;

    private GameObject topFixationPoint;
    private GameObject frontFixationPoint;

    private Transform target;

    private float speed = 1000;

    // Use this for initialization
    void Start()
    {
        FixateInterlocutorPosition();
        topFixationPoint = new GameObject();
        topFixationPoint.transform.position = new Vector3(0f, 150f, 100f);
        frontFixationPoint = new GameObject();
        frontFixationPoint.transform.position = new Vector3(0f, 0f, 100f);

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void FixateInterlocutorPosition()
    {
        target = interlocutorPosition.transform;
    }

    public void FixateUpward()
    {
        target = topFixationPoint.transform;
    }

    public void FixateAhead()
    {
        target = frontFixationPoint.transform;
    }

}
