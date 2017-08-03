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
            animator.SetBool("param_idletorunning",true);

            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("param_idletorunning", false);
                animator.SetBool("jump", true);
            }
            else
            {
                animator.SetBool("jump", false);
            }
        }
        else
        {
            animator.SetBool("param_idletorunning", false);

            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("param_idletorunning", false);
                animator.SetBool("jump", true);
            }
            else
            {
                animator.SetBool("jump", false);
            }
        }        

    }
}
