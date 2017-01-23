using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public GameObject cannonBallLauncher;
    public GameObject rayCaster;
    private int mode = 0;

    //Consts
    private const int NORMAL_MODE = 0;
    private const int LASER_MODE = 1;
    private const int CANNON_MODE = 2;
    private const int MAX = 2;

    private IEnumerator dwellRoutine;

    //init
    private void Start()
    {
       rayCaster.SetActive(false);

        dwellRoutine = Dwell();
        StartCoroutine(dwellRoutine);
    }

	//Keyboard debug
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            switchMode();
        }
	}

    //Launch something
    void Launch()
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

    //switch modes
    void switchMode()
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
    
    //dwell coroutine
    IEnumerator Dwell()
    {
        Quaternion startRot = gameObject.transform.rotation;
        const float threshhold = 0.05f;
        const float waitTime = 0.1f;
        const float dwellTime = 2.0f;
        float curTime = 0.0f;

        while (true)
        {
            //update the time
            yield return new WaitForSeconds(waitTime);
            curTime += waitTime;

            //didn't break threshhold since last update
            if (Mathf.Abs(startRot.x - gameObject.transform.rotation.x) <= threshhold
                && Mathf.Abs(startRot.y - gameObject.transform.rotation.y) <= threshhold
                && Mathf.Abs(startRot.z - gameObject.transform.rotation.z) <= threshhold)
            {
                //if we didn't break threshhold for the total dwell time, active dwell
                if (curTime >= dwellTime)
                {
                    //launch and reset
                    //print("RESET: DWELL");
                    Launch();
                    curTime = 0.0f;
                    startRot = gameObject.transform.rotation;
                }
            }

            //broke threshhold
            else
            {
                //reset
                //print("RESET: BROKE THRESHHOLD");
                curTime = 0.0f;
                startRot = gameObject.transform.rotation;
            }
        }
    }
}
