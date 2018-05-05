using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixationPointMovement : MonoBehaviour {

    public GameObject interlocutorPosition;

    private GameObject topFixationPoint;

    private Transform target;

    private float speed = 50;

    // Use this for initialization
    void Start()
    {
        MoveTowardInterlocutorPosition();
        topFixationPoint = new GameObject();
        topFixationPoint.transform.position = new Vector3(0f, 12f, 15f);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void MoveTowardInterlocutorPosition()
    {
        target = interlocutorPosition.transform;
    }

    public void MoveUp()
    {
        target = topFixationPoint.transform;
    }
}
