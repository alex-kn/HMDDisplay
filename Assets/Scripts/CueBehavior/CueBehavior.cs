using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CueBehavior : MonoBehaviour {

    public GameObject fixationPoint;

    protected FixationPointMovement fixationPointMovement;

    public bool needsAssist = false;
    public bool doNotInterrupt = false;
    public bool expectsResponse = false;
    public bool isAttentive = false;


    public virtual void Start()
    {
        fixationPointMovement = fixationPoint.GetComponent<FixationPointMovement>();
        SetIsAttentive(true);

    }

    public virtual void SetNeedsAssist(bool needsAssist)
    {
        Debug.Log("Assist");
        this.needsAssist = needsAssist;
        if (needsAssist)
        {
            SetDoNotInterrupt(false);
            SetExpectsResponse(true);
            SetIsAttentive(true);
        }
    }

    public virtual void SetDoNotInterrupt(bool doNotInterrupt)
    {
        Debug.Log("DnD");
        this.doNotInterrupt = doNotInterrupt;
        if (doNotInterrupt)
        {
            SetNeedsAssist(false);
            SetExpectsResponse(false);
            SetIsAttentive(false);
        }
    }

    public virtual void SetExpectsResponse(bool expectsResponse)
    {
        Debug.Log("Respond");
        this.expectsResponse = expectsResponse;
        if (expectsResponse)
        {
            SetDoNotInterrupt(false);
            SetIsAttentive(true);
        }
        else
        {
            SetNeedsAssist(false);
        }
    }

    public virtual void SetIsAttentive(bool isAttentive)
    {
        Debug.Log("Attentive");
        this.isAttentive = isAttentive;
        if(isAttentive)
        {
            SetDoNotInterrupt(false);
        }
        else
        {
            SetExpectsResponse(false);
            SetNeedsAssist(false);
        }
    }

    public void ToggleNeedsAssist()
    {
        needsAssist = !needsAssist;
        SetNeedsAssist(needsAssist);
    }

    public void ToggleDoNotInterrupt()
    {
        doNotInterrupt = !doNotInterrupt;
        SetDoNotInterrupt(doNotInterrupt);
    }

    public void ToggleExpectsResponse()
    {
        expectsResponse = !expectsResponse;
        SetExpectsResponse(expectsResponse);
    }

    public void ToggleIsAttentive()
    {
        isAttentive = !isAttentive;
        SetIsAttentive(isAttentive);
    }
}
