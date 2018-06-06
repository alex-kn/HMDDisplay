using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCueBehavior : CueBehavior
{
    private Renderer rend;

    public override void Start()
    {
        base.Start();
        rend = GetComponent<Renderer>();
    }

    protected override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        if (needsAssist)
        {
            rend.material.color = Color.yellow;
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
            rend.material.color = Color.blue;

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
            rend.material.color = Color.red;
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
            rend.material.color = Color.green;
        }
        else
        {
            SetNeutral();
        }
    }

    protected override void SetNeutral()
    {
        rend.material.color = Color.black;
    }
}
