using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCueBehavior : CueBehavior
{

    public GameObject questionMark;


    public override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        //questionMark.SetActive(needsAssist);
        if (needsAssist)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    public override void SetDoNotInterrupt(bool doNotInterrupt)
    {
        base.SetDoNotInterrupt(doNotInterrupt);
        if (doNotInterrupt)
        {
            GetComponent<Renderer>().material.color = Color.red;

        }
    }

    public override void SetIsAttentive(bool isAttentive)
    {
        base.SetIsAttentive(isAttentive);
        if (isAttentive)
        {
            GetComponent<Renderer>().material.color = Color.green;

        }
    }

    public override void SetExpectsResponse(bool expectsResponse)
    {
        base.SetExpectsResponse(expectsResponse);
        if (expectsResponse)
        {
            GetComponent<Renderer>().material.color = Color.blue;

        }
    }
}
