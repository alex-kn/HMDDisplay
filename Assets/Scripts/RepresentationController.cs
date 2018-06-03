using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepresentationController : MonoBehaviour {

    public GameObject[] representations;

    private int activeRepIndex = 0;

    public Button switchRepresentationButton;


    void Start () {
        switchRepresentationButton.onClick.AddListener(SwitchRepresentation);
    
    }

    private void SwitchRepresentation()
    {
        representations[activeRepIndex].SetActive(false);
        activeRepIndex = (activeRepIndex + 1) % representations.Length;
        representations[activeRepIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}


}
