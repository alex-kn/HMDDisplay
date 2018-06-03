using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void LateUpdate()
    {
        if (cueBehavior != null)
        {

            UpdateButtonColor(assistMeButton, cueBehavior.needsAssist);
            UpdateButtonColor(referenceObject, cueBehavior.referencingObject);
            UpdateButtonColor(respondToMeButton, cueBehavior.expectsResponse);
            UpdateButtonColor(iAmAttentiveButton, cueBehavior.isAttentive);
        }
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

    private void UpdateButtonColor(Button button, bool value)
    {
        if (value)
        {
            ColorBlock cb = button.colors;
            cb.normalColor = Color.green;
            cb.highlightedColor = Color.green;
            button.colors = cb;
        }
        else
        {
            ColorBlock cb = button.colors;
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
            button.colors = cb;
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

    enum CueCode
    {
        Assist = 1,
        Attentive = 2,
        Referencing = 3,
        Response = 4

    }
}
