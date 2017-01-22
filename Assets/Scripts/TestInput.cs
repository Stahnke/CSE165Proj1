using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour {

    public GameObject cannonBallLauncher;
    public GameObject rayCaster;
    private int mode = 0;

    //Consts
    private const int NORMAL_MODE = 0;
    private const int LASER_MODE = 1;
    private const int CANNON_MODE = 2;
    private const int MAX = 2;

    //init
    private void Start()
    {
        rayCaster.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            //Laser mode
            if (mode == LASER_MODE)
            {
                rayCaster.GetComponent<RayCastDetect>().Launch();
            }

            //Cannon mode
            else if (mode == CANNON_MODE)
            {
                cannonBallLauncher.GetComponent<CannonBallLauncher>().Launch();
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            //Change mode
            if (mode < MAX)
                mode++;
            else
                mode = 0;

            //Update the mode settings
            if (mode == NORMAL_MODE)
                rayCaster.SetActive(false);
            else if (mode == LASER_MODE)
                rayCaster.SetActive(true);
            else if (mode == CANNON_MODE)
                rayCaster.SetActive(false);

        }
	}
}
