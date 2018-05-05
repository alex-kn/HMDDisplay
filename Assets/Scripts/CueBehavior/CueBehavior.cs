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

    public void Update()
    {
        Debug.Log(needsAssist);
    }

    public virtual void SetNeedsAssist(bool needsAssist)
    {
        if (this.needsAssist == needsAssist) return;
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
        if (this.doNotInterrupt == doNotInterrupt) return;
        this.doNotInterrupt = doNotInterrupt;
        if (doNotInterrupt)
        {
            SetNeedsAssist(false);
            SetExpectsResponse(false);
            SetIsAttentive(false);
        }
        else
        {
            SetIsAttentive(true);
        }
    }

    public virtual void SetExpectsResponse(bool expectsResponse)
    {
        if (this.expectsResponse == expectsResponse) return;
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
        if (this.isAttentive == isAttentive) return;
        this.isAttentive = isAttentive;
        if(isAttentive)
        {
            SetDoNotInterrupt(false);
        }
        else
        {
            SetExpectsResponse(false);
            SetNeedsAssist(false);
            SetDoNotInterrupt(true);
        }
    }

    public void ResetCues()
    {
        SetNeedsAssist(false);
        SetIsAttentive(false);
        SetDoNotInterrupt(false);
        SetExpectsResponse(false);
    }

    public void ToggleNeedsAssist()
    {
        SetNeedsAssist(!needsAssist);
    }

    public void ToggleDoNotInterrupt()
    {
        SetDoNotInterrupt(!doNotInterrupt);
    }

    public void ToggleExpectsResponse()
    {
        SetExpectsResponse(!expectsResponse);
    }

    public void ToggleIsAttentive()
    {
        SetIsAttentive(!isAttentive);
    }
}
