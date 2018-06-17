using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controls which cue is currently active
 */
public class CueClickController : MonoBehaviour
{

    public Button assistMeButton;
    public Button referenceObject;
    public Button respondToMeButton;
    public Button iAmAttentiveButton;


    private CueBehavior cueBehavior;

    void Start()
    {
        assistMeButton.onClick.AddListener(AssistMe);
        referenceObject.onClick.AddListener(ReferencinObject);
        respondToMeButton.onClick.AddListener(RespondToMe);
        iAmAttentiveButton.onClick.AddListener(IAmAttentive);
    }

    internal void ActivateCue(string cueCode)
    {
        Debug.Log("Activating Cue " + cueCode);
        switch (cueCode)
        {
            case "1":
                AssistMe();
                break;
            case "2":
                IAmAttentive();
                break;
            case "3":
                ReferencinObject();
                break;
            case "4":
                RespondToMe();
                break;
            default:
                Debug.LogError("Cue code not found");
                break;
        }
    }
   

    void AssistMe()
    {
        cueBehavior.ToggleNeedsAssist();
    }

    void ReferencinObject()
    {
        cueBehavior.ToggleReferencingObject();
    }

    void RespondToMe()
    {
        cueBehavior.ToggleExpectsResponse();
    }

    void IAmAttentive()
    {
        cueBehavior.ToggleIsAttentive();
    }

    public void SetCueBehavior(CueBehavior cueBehavior)
    {
        this.cueBehavior = cueBehavior;
    }
}
