using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float movement = 10.0f;
    public float rotateSpeed = 2.0f;
    Rigidbody rb;

    float moveX = 0f; //左右の移動
    float moveZ = 0f; //前後の移動

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        moveX = Input.GetAxis("Horizontal") * movement;
        moveZ = Input.GetAxis("Vertical") * movement;
        rb.velocity = new Vector3(moveX, 0, moveZ);
        //移動した際の振り向き処理
        Vector3 direction = new Vector3(moveX, 0, moveZ);
        if (direction.magnitude > 0.01f)
        //Vector3.magnitude →移動したら以下処理起動
        //ベクトルの長さを返します（読み取り専用）
        //ベクトルの(x * x + y * y + z * z) の平方根の長さを返します
        {
            float step = rotateSpeed * Time.deltaTime;
            Quaternion myQ = Quaternion.LookRotation(direction);
            //クォータ二オンは回転を表すのに使用されます。
            transform.rotation = Quaternion.Lerp(transform.rotation, myQ, step);
            //Vector3.Lerp
            //直線上にある 2 つのベクトル間を補間します
        }
    }
}
