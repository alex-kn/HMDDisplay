using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCueBehavior : CueBehavior
{

    public GameObject assText;
    public GameObject refText;
    public GameObject resText;
    public GameObject attText;

    public override void Start()
    {
        base.Start();
        GetComponent<Renderer>().material.color = Color.black;
    }

    protected override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        assText.SetActive(needsAssist);
    }

    protected override void SetReferencingObject(bool referencingObject)
    {
        base.SetReferencingObject(referencingObject);
        refText.SetActive(referencingObject);
    }

    protected override void SetIsAttentive(bool isAttentive)
    {
        base.SetIsAttentive(isAttentive);
        attText.SetActive(isAttentive);

    }

    protected override void SetExpectsResponse(bool expectsResponse)
    {
        base.SetExpectsResponse(expectsResponse);
        resText.SetActive(expectsResponse);

    }

    protected override void SetNeutral()
    {
        attText.SetActive(false);
        refText.SetActive(false);
        resText.SetActive(false);
        assText.SetActive(false);
    }
}
