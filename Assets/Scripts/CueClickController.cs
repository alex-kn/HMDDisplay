using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CueClickController : MonoBehaviour
{

    public Button assistMeButton;
    public Button doNotInterruptMe;
    public Button respondToMeButton;
    public Button iAmAttentiveButton;

    public RepresentationController repControl;
    public Button switchRepresentationButton;

    private CueBehavior cueBehavior;

    public GameObject[] representations;
    private int activeRepIndex;

    void Start()
    {
        assistMeButton.onClick.AddListener(AssistMe);
        doNotInterruptMe.onClick.AddListener(ReferencinObject);
        respondToMeButton.onClick.AddListener(RespondToMe);
        iAmAttentiveButton.onClick.AddListener(IAmAttentive);
        //switchRepresentationButton.onClick.AddListener(SwitchRepresentation);
        activeRepIndex = 0;
        foreach (GameObject representation in representations)
        {
            representation.SetActive(false);
        }

    }

    private void LateUpdate()
    {
        if (cueBehavior != null)
        {

            UpdateButtonColor(assistMeButton, cueBehavior.needsAssist);
            UpdateButtonColor(doNotInterruptMe, cueBehavior.referencingObject);
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

    void SwitchRepresentation()
    {
        representations[activeRepIndex].SetActive(false);
        activeRepIndex = (activeRepIndex + 1) % representations.Length;
        representations[activeRepIndex].SetActive(true);
        cueBehavior = GetCueBehavior();
    }

    void AssistMe()
    {
        cueBehavior = GetCueBehavior();
        cueBehavior.ToggleNeedsAssist();
    }

    void ReferencinObject()
    {
        cueBehavior = GetCueBehavior();
        cueBehavior.ToggleReferencingObject();
    }

    void RespondToMe()
    {
        cueBehavior = GetCueBehavior();
        cueBehavior.ToggleExpectsResponse();
    }

    void IAmAttentive()
    {
        cueBehavior = GetCueBehavior();
        cueBehavior.ToggleIsAttentive();
    }

    private CueBehavior GetCueBehavior()
    {
        GameObject augmentation = GameObject.FindWithTag("Augmentation");

        if (augmentation != null)
        {
            Debug.Log("Augmentation found.");
            CueBehavior cueBehavior = augmentation.GetComponent(typeof(CueBehavior)) as CueBehavior;
            return cueBehavior;
        }
        else
        {
            throw new System.Exception("No Augmentation found.");
        }
    }

    enum CueCode
    {
        Assist = 1,
        Attentive = 2,
        Referencing = 3,
        Response = 4

    }
}
