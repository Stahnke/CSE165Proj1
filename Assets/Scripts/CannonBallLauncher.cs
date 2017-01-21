using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallLauncher : MonoBehaviour {

    public GameObject cannonBallPrefab;
    public Transform cannonBallSpanwerTrans;
    public float launchForce = 50000.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Launch()
    {
        GameObject cannonBall = Instantiate(cannonBallPrefab, cannonBallSpanwerTrans.position, Quaternion.identity);
        cannonBall.GetComponent<Rigidbody>().AddForce(transform.forward * launchForce);
    }
}
