using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCueBehavior : CueBehavior
{


    protected override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        if (needsAssist)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            SetNeutral();
        }
    }

    protected override void SetReferencingObject(bool referencingObject)
    {
        base.SetReferencingObject(referencingObject);
        if (referencingObject)
        {
            GetComponent<Renderer>().material.color = Color.yellow;

        }
        else
        {
            SetNeutral();
        }
    }

    protected override void SetIsAttentive(bool isAttentive)
    {
        base.SetIsAttentive(isAttentive);
        if (isAttentive)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            SetNeutral();
        }
    }

    protected override void SetExpectsResponse(bool expectsResponse)
    {
        base.SetExpectsResponse(expectsResponse);
        if (expectsResponse)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            SetNeutral();
        }
    }

    protected override void SetNeutral()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
