using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyMinnow.SALSA;


public class NonRealEyesCueBehavior : CueBehavior
{

    protected override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        if (needsAssist)
        {
            fixationPointMovement.FixateInterlocutorPosition();
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
            fixationPointMovement.FixateAhead();
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
            fixationPointMovement.FixateInterlocutorPosition();
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
            fixationPointMovement.FixateUpward();
        }
        else
        {
            SetNeutral();
        }
    }

    protected override void SetNeutral()
    {
        fixationPointMovement.FixateAhead();
    }
}
