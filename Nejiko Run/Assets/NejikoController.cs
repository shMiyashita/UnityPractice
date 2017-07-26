using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour
{

    //キャラクターの動きをレーンに絞る(追記)
    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    //ダメージ、ライフの処理(追記)
    const int DefaultLife = 3;
    const float StunDuration = 0.5f;

    CharacterController controller; //キャラクターコントローラーのための変数
    Animator animator; //アニメーターを適用するための変数

    Vector3 moveDirection = Vector3.zero; //移動方向(この関数内でのみ使用)
    int targetLane; //追記
    int life = DefaultLife;//追記・ライフ
    float recoverTime = 0.0f;//追記・復帰までの時間

    public float gravity; //重力
    public float speedZ; //スピード
    public float speedX; //横方向のスピードパラメータ(追記)
    public float speedJump; //ジャンプスピード？
    public float accelerazationZ; //前進加速度のパラメータ(追記)

    //ライフ取得用関数
    public int Life()
    {
        return life;
    }

    //気絶判定
    public bool IsStan()
    {
        //敵と接触したときに設定されるrecoverTimeが0より大きいとき、もしくはlifeがなくなった時に行動できない旨を返す
        return recoverTime > 0.0f || life <= 0;
    }

    // Use this for initialization
    void Start()
    {
        //必要なコンポーネントを自動取得
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ////地上にいる場合のみ操作可能にする
        //if (controller.isGrounded)
        //{
        //    //前進ベロシティの設定
        //    if (Input.GetAxis("Vertical") > 0.0f)
        //    {
        //        moveDirection.z = Input.GetAxis("Vertical") * speedZ;
        //    }
        //    else
        //    {
        //        moveDirection.z = 0;
        //    }

        //    //方向転換
        //    transform.Rotate(0, Input.GetAxis("Horizontal") * 3, 0);

        //    //ジャンプ
        //    if (Input.GetButton("Jump"))
        //    {
        //        moveDirection.y = speedJump;
        //        animator.SetTrigger("jump");
        //    }

        //}

        //デバッグ用
        if (Input.GetKeyDown("left")) MoveToLeft();
        if (Input.GetKeyDown("right")) MoveToRight();
        if (Input.GetKeyDown("space")) Jump();

        //気絶時の行動
        if (IsStan())
        {
            //動きを止め気絶状態からの復帰カウントを進める
            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            //徐々に加速しZ方向に常に前進させる
            //前進velocityの計算
            float acceleratedZ = moveDirection.z + (accelerazationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);
        }

        //X方向は目標のポジションまでの差分の割合で速度を計算
        //横方向のvelocityの計算
        float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
        moveDirection.x = ratioX * speedX;

        //重力分の力を毎フレーム追加
        moveDirection.y -= gravity * Time.deltaTime;

        //移動実行
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        //deltatime→FPSの違いによるキャラクターの移動距離の違いを吸収する
        controller.Move(globalDirection * Time.deltaTime);

        //移動後設置してたらY方向の速度はリセットする→浮いてたら重力を加算したりしてるから
        if (controller.isGrounded) moveDirection.y = 0;

        //速度が0以上なら走っているフラグをtrueにする
        animator.SetBool("run", moveDirection.z > 0.0f);
        //setBoolの中で第二引数の部分をif文の条件にする？
    }

    //左のレーンに移動を開始
    public void MoveToLeft()
    {
        //気絶時の入力キャンセル
        if (IsStan()) return;
        if (controller.isGrounded && targetLane > MinLane) targetLane--;
    }

    //右のレーンに移動を開始
    public void MoveToRight()
    {
        //気絶時の入力キャンセル
        if (IsStan()) return;
        if (controller.isGrounded && targetLane < MaxLane) targetLane++;
    }

    //ジャンプ関数
    public void Jump()
    {
        //気絶時の入力キャンセル
        if (IsStan()) return;
        if (controller.isGrounded)
        {
            moveDirection.y = speedJump;

            //ジャンプトリガーを設定
            animator.SetTrigger("jump");
        }
    }

    //ChraracterControllerにコリジョンが生じたときの処理
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (IsStan()) return;

        if(hit.gameObject.tag == "Robo")
        {
            //ライフを減らして気絶状態に移行
            life--;
            recoverTime = StunDuration;

            //ダメージトリガーを設定
            animator.SetTrigger("damage");

            //ヒットしたオブジェクトは削除
            Destroy(hit.gameObject);
        }
    }
}