using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

    public float ballSpeed = 10.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, ballSpeed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
