using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEyes : MonoBehaviour {

    public GameObject eyes;
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(eyes.transform);
	}
}
