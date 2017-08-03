using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour {

    Animator animator;
    CharacterController cc;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
        //モーションの切り替え
        if(cc.velocity.magnitude > 0f)
        {
            animator.SetTrigger("param_idletorunning");
        }
        else
        {
            animator.ResetTrigger("param_idletorunning");
        }
	}
}
