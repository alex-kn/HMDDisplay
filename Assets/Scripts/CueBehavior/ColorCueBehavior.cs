using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCueBehavior : CueBehavior
{

    private Image image;

    public override void Start()
    {
        base.Start();
        image = GetComponent<Image>();
    }

    protected override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        if (needsAssist)
        {
            image.color = Color.yellow;
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
            image.color = Color.blue;

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
            image.color = Color.red;
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
            image.color = Color.green;
        }
        else
        {
            SetNeutral();
        }
    }

    protected override void SetNeutral()
    {
        image.color = Color.black;
    }
}
