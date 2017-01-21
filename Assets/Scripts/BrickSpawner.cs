using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour {

    public Transform spawnerParentTrans;
    public Transform spawnerChildTrans;
    public GameObject brickPrefab;
    public int HEIGHT = 20;
    private const float ROTATION = 7.5f;
    private const int CIRCLE_DEG = 360;

	// Use this for initialization
	void Start () {
        for (int y = 0; y < HEIGHT; y++)
        {
            for (int x = 0; x < CIRCLE_DEG / ROTATION; x++)
            {
                Instantiate(brickPrefab, spawnerChildTrans.position, spawnerParentTrans.rotation);
                spawnerParentTrans.Rotate(0.0f, ROTATION, 0.0f, Space.Self);
            }
            spawnerParentTrans.Translate(0.0f, brickPrefab.transform.localScale.y, 0.0f);
            spawnerParentTrans.Rotate(0.0f, ROTATION / 2, 0.0f, Space.Self);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
