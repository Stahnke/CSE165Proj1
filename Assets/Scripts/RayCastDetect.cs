using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDetect : MonoBehaviour {

	public void Launch() {

        if (Physics.Raycast(transform.position, Vector3.forward, 100))
            print("There is something in front of the object!");
    }
}
