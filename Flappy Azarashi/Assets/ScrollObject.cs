using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour {

    public float speed = 1.0f;
    public float startPositions;
    public float endPosition;
	
	// Update is called once per frame
	void Update () {

        //毎フレームxポジションを少しずつ移動させる
        //何もつけていないtransformは、このスクリプトを適用したオブジェクト自身になるので、
        //背景に設定すると、背景が少しずつ動くことになる
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        //スクロールが目標ポイントまで到達したかをチェックする
        if (transform.position.x <= endPosition) ScrollEnd();
	}

    void ScrollEnd()
    {
        //スクロールする距離分を戻す(ローテーションの処理)
        transform.Translate(-1 * (endPosition - startPositions), 0, 0);

        //同じゲームオブジェクトにアタッチされているコンポーネントにメッセージを送る(?)
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
        //OnscrollEndを引数に持つコンポーネントがこれで動作する？
    }


}
