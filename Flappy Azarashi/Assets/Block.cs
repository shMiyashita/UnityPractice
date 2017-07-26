using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public float minHeight;
	public float maxHeight;
	public GameObject pivot;

	//高さを自動調整して出現させ続けるクラス。ScrollObjectと連動して稼動する
	//最初の出現はStartに入れて、その後はOnScrollEndMessageを受け取って動くようにする

	// Use this for initialization
	void Start () {

		//開始時に隙間の高さを変更
		ChangeHeight();

	}
	
	void ChangeHeight()
	{
		//ランダムな高さを生成して設定
		float height = Random.Range(minHeight, maxHeight);
		pivot.transform.localPosition = new Vector3(0.0f, height, 0.0f);
	}

	//ScrollObjectスクリプトからメッセージを受け取って高さを変更(高さをランダムに再設定)
	void OnScrollEnd()
	{
		ChangeHeight();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
