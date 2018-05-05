using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRealEyesCueBehavior : CueBehavior
{

    public override void SetNeedsAssist(bool needsAssist)
    {
        if (needsAssist)
        {
            fixationPointMovement.MoveTowardInterlocutorPosition();
        }
        base.SetNeedsAssist(needsAssist);
    }

    public override void SetDoNotInterrupt(bool doNotInterrupt)
    {
        if (doNotInterrupt)
        {
            fixationPointMovement.MoveUp();
        }
        else
        {
            fixationPointMovement.MoveTowardInterlocutorPosition();
        }
        base.SetDoNotInterrupt(doNotInterrupt);
    }

    public override void SetExpectsResponse(bool expectsResponse)
    {
        if (expectsResponse)
        {
            fixationPointMovement.MoveTowardInterlocutorPosition();
        }
        base.SetExpectsResponse(expectsResponse);
    }

    public override void SetIsAttentive(bool isAttentive)
    {
        if (isAttentive)
        {
            fixationPointMovement.MoveTowardInterlocutorPosition();
        }
        else
        {
            fixationPointMovement.MoveUp();
        }
        base.SetIsAttentive(isAttentive);
    }
}
