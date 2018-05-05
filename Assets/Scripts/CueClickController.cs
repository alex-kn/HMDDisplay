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


    void Start()
    {
        assistMeButton.onClick.AddListener(AssistMe);
        doNotInterruptMe.onClick.AddListener(DoNotInterrupt);
        respondToMeButton.onClick.AddListener(RespondToMe);
        iAmAttentiveButton.onClick.AddListener(IAmAttentive);
    }

    void AssistMe()
    {
        CueBehavior cueBehavior = GetCueBehavior();
        cueBehavior.ToggleNeedsAssist();
    }

    void DoNotInterrupt()
    {
        CueBehavior cueBehavior = GetCueBehavior();
        cueBehavior.ToggleDoNotInterrupt();
    }

    void RespondToMe()
    {
        CueBehavior cueBehavior = GetCueBehavior();
        cueBehavior.ToggleExpectsResponse();
    }

    void IAmAttentive()
    {
        CueBehavior cueBehavior = GetCueBehavior();
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
