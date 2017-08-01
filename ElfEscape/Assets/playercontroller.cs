using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {

    Vector3 moveDirection = Vector3.zero; //移動方向(この関数内でのみ使用)
    public float speedZ;
    CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        //前進ベロシティの設定
        moveDirection.z =  speedZ;

        //移動実行
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        //deltatime→FPSの違いによるキャラクターの移動距離の違いを吸収する
        cc.Move(globalDirection * Time.deltaTime);
    }
}
