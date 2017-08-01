using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public GameObject target; //付いていく対象
    public float followSpeed; //付いていく速度
    Vector3 distanceToTarget; //対象との距離

	// Use this for initialization
	void Start () {
        //ターゲットとどのくらいの距離を保ちながら追従するかを、スタート時の位置に応じて計算しておく
        distanceToTarget = target.transform.position - transform.position;
    }

    // Update is called once per frame
    // LateUpdate･･･すべてのupdateが終わったあとに実行される
    // よって、キャラクターの移動がすべて終わってからupdateを実行することが可能
    void LateUpdate()
    {
        // Vector3.Lerp･･･線形補完関数
        // 現在のポジションと目標のポジションの間の距離を一定の割合で縮めていく処理を行っている
        // これにより、距離が離れているほどすばやく近づき、距離が近いほどゆっくり近づくため、
        // なめらかな動きで追従する動きを再現できる 覚えておくと便利
        transform.position = Vector3.Lerp(
            transform.position,
            target.transform.position - distanceToTarget,
            Time.deltaTime * followSpeed
            );
    }
}
