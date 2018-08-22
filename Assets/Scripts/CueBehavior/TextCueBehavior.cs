using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCueBehavior : CueBehavior
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
            text.text = "Help";
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
            text.text = "This one";
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
            text.text = "Not Attentive";
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
            text.text = "Your Turn";
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
