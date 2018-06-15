using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepresentationController : MonoBehaviour {

    public GameObject[] representations;

    public CueClickController cueClickController;

    private int activeRepIndex = 0;

    public Button switchRepresentationButton;

    public InterlocutorPosition interlocutorPosition;

    void Start () {
        switchRepresentationButton.onClick.AddListener(SwitchRepresentation);
        foreach (GameObject representation in representations)
        {
            representation.SetActive(false);
        }
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
