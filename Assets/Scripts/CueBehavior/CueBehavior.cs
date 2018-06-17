using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls the cues that the augmentation is displaying. Only one cue can be active at a time.
 */
public abstract class CueBehavior : MonoBehaviour {

    public GameObject fixationPoint;

    protected FixationPointMovement fixationPointMovement;

    public bool needsAssist = false;
    public bool referencingObject = false;
    public bool expectsResponse = false;
    public bool isAttentive = false;

    public virtual void Start()
    {
        fixationPointMovement = fixationPoint.GetComponent<FixationPointMovement>();
    }

    protected virtual void SetNeedsAssist(bool needsAssist)
    {
        if (this.needsAssist == needsAssist) return;
        this.needsAssist = needsAssist;
    }

    protected virtual void SetReferencingObject(bool referencingObject)
    {
        if (this.referencingObject == referencingObject) return;
        this.referencingObject = referencingObject;
    }

    protected virtual void SetExpectsResponse(bool expectsResponse)
    {
        if (this.expectsResponse == expectsResponse) return;
        this.expectsResponse = expectsResponse;
    }

    protected virtual void SetIsAttentive(bool isAttentive)
    {
        if (this.isAttentive == isAttentive) return;
        this.isAttentive = isAttentive;
    }


    protected abstract void SetNeutral();

    public void ToggleNeedsAssist()
    {
        SetIsAttentive(false);
        SetReferencingObject(false);
        SetExpectsResponse(false);
        SetNeedsAssist(!needsAssist);
    }

    public void ToggleReferencingObject()
    {
        SetNeedsAssist(false);
        SetIsAttentive(false);
        SetExpectsResponse(false);
        SetReferencingObject(!referencingObject);
    }

    public void ToggleExpectsResponse()
    {
        SetNeedsAssist(false);
        SetIsAttentive(false);
        SetReferencingObject(false);
        SetExpectsResponse(!expectsResponse);
    }

    public void ToggleIsAttentive()
    {
        SetNeedsAssist(false);
        SetReferencingObject(false);
        SetExpectsResponse(false);
        SetIsAttentive(!isAttentive);
    }
}
