using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls the Motion of the FixationPoint.
 * The FixationPoint is the Spot the Eyes are lookint at at any time.
 */
public class FixationPointMovement : MonoBehaviour {

    public GameObject interlocutorPosition;

    private GameObject topFixationPoint;
    private GameObject frontFixationPoint;

    private Transform target;
    private float oldDelta;

    private float speed = 1000;

    // Use this for initialization
    void Start()
    {
        FixateInterlocutorPosition();
        topFixationPoint = new GameObject();
        topFixationPoint.transform.position = new Vector3(0f, 80f, 100f);
        frontFixationPoint = new GameObject();
        frontFixationPoint.transform.position = new Vector3(0f, 0f, 500f);

    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        if(Vector3.Distance(transform.position,target.position) > 30)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        }

        float x = Random.Range(0, 500);
        if (x > 485)
        {

            float delta = Random.Range(-10, 10);
            transform.Translate(new Vector3(delta - oldDelta, 0, 0));
            oldDelta = delta;


        }
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
