using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject target;

    public GameObject shot;

    float shotInterval = 0;
    float shotIntervalMax = 1f;

	// Use this for initialization
	void Start () {

        //ターゲット取得
        target = GameObject.Find("PlayerTarget");

	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(target.transform);

        shotInterval += Time.deltaTime;

        if(shotInterval > shotIntervalMax)
        {
            Instantiate(shot, transform.position, transform.rotation);
            shotInterval = 0;
        }



	}
}
