using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_controller : MonoBehaviour {

    public GameObject ballPrefab;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 placePosition = new Vector3(4.5f, -3f, -6f);

        if (Input.GetButtonDown("Fire1")){
            Instantiate(ballPrefab, placePosition, Quaternion.identity);
        }

    }
}
