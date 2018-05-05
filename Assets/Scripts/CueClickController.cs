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

    public Button switchRepresentationButton;

    private CueBehavior cueBehavior;

    public GameObject[] representations;
    private int activeRepIndex;

    void Start()
    {
        assistMeButton.onClick.AddListener(AssistMe);
        doNotInterruptMe.onClick.AddListener(DoNotInterrupt);
        respondToMeButton.onClick.AddListener(RespondToMe);
        iAmAttentiveButton.onClick.AddListener(IAmAttentive);
        switchRepresentationButton.onClick.AddListener(SwitchRepresentation);
        activeRepIndex = 0;
        SwitchRepresentation();
        cueBehavior = GetCueBehavior();
    }

    private void LateUpdate()
    {
        UpdateButtonColor(assistMeButton, cueBehavior.needsAssist);
        UpdateButtonColor(doNotInterruptMe, cueBehavior.doNotInterrupt);
        UpdateButtonColor(respondToMeButton, cueBehavior.expectsResponse);
        UpdateButtonColor(iAmAttentiveButton, cueBehavior.isAttentive);
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
        cueBehavior.ResetCues();
    }

    void AssistMe()
    {
        cueBehavior = GetCueBehavior();
        cueBehavior.ToggleNeedsAssist();
    }

    void DoNotInterrupt()
    {
        cueBehavior = GetCueBehavior();
        cueBehavior.ToggleDoNotInterrupt();
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
}
