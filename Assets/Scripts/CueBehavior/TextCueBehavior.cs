using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCueBehavior : CueBehavior
{

    public GameObject assText;
    public GameObject dndText;
    public GameObject resText;
    public GameObject attText;

    public override void Start()
    {
        base.Start();
        GetComponent<Renderer>().material.color = Color.black;
    }

    public override void SetNeedsAssist(bool needsAssist)
    {
        base.SetNeedsAssist(needsAssist);
        assText.SetActive(needsAssist);
    }

    public override void SetDoNotInterrupt(bool doNotInterrupt)
    {
        base.SetDoNotInterrupt(doNotInterrupt);
        dndText.SetActive(doNotInterrupt);
    }

    public override void SetIsAttentive(bool isAttentive)
    {
        base.SetIsAttentive(isAttentive);
        attText.SetActive(isAttentive);

    }

    public override void SetExpectsResponse(bool expectsResponse)
    {
        base.SetExpectsResponse(expectsResponse);
        resText.SetActive(expectsResponse);

    }
}
