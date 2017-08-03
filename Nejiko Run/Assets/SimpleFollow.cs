using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour {

    //追従する距離
    Vector3 diff;

    //追従する対象(ねじこ)
    //カメラを追従させる対象のオブジェクトをInspectorビューから指定する
    public GameObject target;
    //付いていくスピード
    public float followSpeed;

	// Use this for initialization
	void Start () {
        //ターゲットとどのくらいの距離を保ちながら追従するかを、スタート時の位置に応じて
        //計算しておく
        diff = target.transform.position - transform.position;
	}

	// Update is called once per frame
    //LateUpdateとは？→すべてのupdateが終わったあとに実行される。
    //よって、キャラクターの移動がすべて終わってからupdateを実行することが可能
	void LateUpdate () {
        //Vector3.Lerp→線形補完関数
        //→現在のポジションと目標のポジションの間の距離を一定の割合で縮めていく処理を行っている。
        //これにより、距離が離れているほどすばやく近づき、距離が近いほどゆっくり近づくため、
        //なめらかな動きで追従する動きを再現できる。覚えておくと便利。
        transform.position = Vector3.Lerp(
            transform.position,
            target.transform.position - diff,
            Time.deltaTime * followSpeed
            );
	}
}
