using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GermanTextCueBehavior : CueBehavior
{

    public Text text;

    public override void Start()
    {
        base.Start();
    }

    protected override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        if (needsAssist)
        {
            text.text = "Hilfe";
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
            text.text = "Das da";
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
            text.text = "Nicht Aufmerksam";
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
            text.text = "Du bist dran";
        }
        else
        {
            SetNeutral();
        }

    }

    protected override void SetNeutral()
    {
        text.text = " ";
    }
}
