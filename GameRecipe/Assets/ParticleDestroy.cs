using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //パーティクル終了時に自動的に消滅させる
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        Destroy(gameObject, main.duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
