using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRealEyesCueBehavior : CueBehavior {

    public override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        fixationPointMovement.MoveTowardInterlocutorPosition();
    }

    public override void SetDoNotInterrupt(bool doNotInterrupt)
    {
        base.SetDoNotInterrupt(doNotInterrupt);
        fixationPointMovement.MoveUp();
    }

    public override void SetExpectsResponse(bool expectsResponse)
    {
        base.SetExpectsResponse(expectsResponse);
    }

    public override void SetIsAttentive(bool isAttentive)
    {
        base.SetIsAttentive(isAttentive);
    }
}
