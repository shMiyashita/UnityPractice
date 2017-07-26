using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azarashicontroller : MonoBehaviour {

    Rigidbody2D rb2d;
    //アニメーションの制御
    Animator animator;
    float angle;
	bool isDead; //死亡判定

	public float maxHeight;
    public float flapVelocity;
    //アニメーションの制御
    public float relativeVelocityX;
    public GameObject sprite; //スプライトオブジェクトの参照

	public bool IsDead()
	{
		return isDead;
	}

    // Use this for initialization
    void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		//最高高度に達していない場合に限りタップの入力を受け付ける
        if(Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            Flap();
        }

        //角度を反映
        ApplyAngle();

        //angleが水平以上だったら、アニメーターのflapフラグをtrueにする
        animator.SetBool("flap", angle >= 0.0f); //アニメーションステートの制御

	}

    public void Flap()
    {
		//死んだら羽ばたけない
		if (isDead) return;

		//重力が効いてないときは操作しない
		if (rb2d.isKinematic) return;

        //Velocityを直接書き換えて上方向に加速
        rb2d.velocity = new Vector2(0.0f, flapVelocity);
    }

    void ApplyAngle()
    {
		//現在の速度、相対速度から進んでいる角度を求める(ベクトルから角度の計算)
		float targetAngle;

		//死亡したら常に下を向く
		if (isDead)
		{
			targetAngle = -90.0f;
		}
		else
		{
			targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
		}
		
		//回転アニメをスムージング 角度反映スムージング
		angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10.0f);

        //Rotationの反映
        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);

	}

	//コリジョンによる死亡判定
	void OnCollisionEnter2D (Collision2D collision)
	{
		if (isDead) return;

		//クラッシュエフェクト
		Camera.main.SendMessage("Clash");

		//何かにぶつかったら死亡フラグを立てる
		isDead = true;
	}

	public void SetSteerActive(bool active)
	{
		//Rigidboidyのオン、オフを切り替える
		rb2d.isKinematic = !active;
	}
}
