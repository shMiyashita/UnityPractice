using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public float speed = 15f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public Vector3 moveDirection = Vector3.zero;

    CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (cc.isGrounded)
        {
            //移動
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

            //向きを変える
            transform.Rotate(0, Input.GetAxis("Horizontal2") * 3, 0);

            //カメラを回転させる
            Camera.main.transform.Rotate(Input.GetAxis("Vertical2"), 0, 0);

        }

        moveDirection.y -= gravity * Time.deltaTime;
        cc.Move(moveDirection * Time.deltaTime);

	}
}
