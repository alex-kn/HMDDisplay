using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEyes : MonoBehaviour {

    public GameObject eyes;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(eyes.transform);

	}
}
