using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject shot;

    float shotInterval = 0;
    float shotIntervalMax = 0.05f;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update () {

        //発射間隔を調整する
        shotInterval += Time.deltaTime;

        //球を発射する
        if (Input.GetButton("Fire1"))
        {
            if(shotInterval > shotIntervalMax)
            {
                Instantiate(shot, transform.position, Camera.main.transform.rotation);
                shotInterval = 0;
            }

        }
	}
}
