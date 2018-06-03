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

    void Start () {
        //cueClickController = cueControl.GetComponent<CueClickController>();
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
    }

    // Update is called once per frame
    void Update () {
		
	}


}
