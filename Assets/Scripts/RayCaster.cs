using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    RaycastHit hit;
    GameObject otherObject;

    public bool Launch() {

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 100))
        {
            otherObject = hit.collider.gameObject;
            if (otherObject != null)
            {
                print("Raycast detect object: " + otherObject.name);
                if(otherObject.CompareTag("switchBox"))
                {
                    int mode = otherObject.GetComponent<ModeBox>().Switch();
                    GetComponentInParent<InputManager>().SwitchMode(mode);
                    return true;
                }
                else if(otherObject.CompareTag("resetPlane"))
                {
                    GetComponentInParent<InputManager>().resetScene();
                }
            }
        }
        return false;
    }
}
