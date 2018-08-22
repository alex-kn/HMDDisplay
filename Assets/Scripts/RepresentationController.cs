using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controls the currently shown augmentation
 */
public class RepresentationController : MonoBehaviour {

    public GameObject[] representations;

    public CueClickController cueClickController;

    private int activeRepIndex = 0;

    //this button is invisible and located in the center of the screen. 
    //To change augmentation click in the center of the screen
    public Button switchRepresentationButton;

    public InterlocutorPosition interlocutorPosition;

    void Start () {
        switchRepresentationButton.onClick.AddListener(SwitchRepresentation);
        foreach (GameObject representation in representations)
        {
            representation.SetActive(false);
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        switchRepresentationButton.GetComponentInChildren<Text>().text = "";
    }

    public void SwitchRepresentation()
    {
        representations[activeRepIndex].SetActive(false);
        activeRepIndex = (activeRepIndex + 1) % representations.Length;
        representations[activeRepIndex].SetActive(true);
        cueClickController.SetCueBehavior(representations[activeRepIndex].GetComponent<CueBehavior>());
        if (activeRepIndex == 0)
        {
            interlocutorPosition.TurnOnFaceTracking();
            
        }
        else
        {
            interlocutorPosition.TurnOffFaceTracking();
            
        }
    }

}
