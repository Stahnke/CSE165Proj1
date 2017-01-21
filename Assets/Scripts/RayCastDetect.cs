using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDetect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Physics.Raycast(transform.position, Vector3.forward, 100))
            print("There is something in front of the object!");
    }
}
