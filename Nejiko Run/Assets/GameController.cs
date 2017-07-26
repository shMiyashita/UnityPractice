﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public NejikoController nejiko;
    public Text scoreLabel; //UnityEngine.UIライブラリをインポートする
    public LifePanel lifePanel;
	
	// Update is called once per frame
	void Update () {

        //スコアラベルを更新
        int score = CalcScore();
        scoreLabel.text = "score :" + score + "m";

        //ライフパネルを更新
        lifePanel.updateLife(nejiko.Life());

        //ねじ子のライフが0になったらゲームオーバー
        if(nejiko.Life() <= 0)
        {
            //これ以降のUpdateは止める
            enabled = false;

            //ハイスコア更新
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            //2秒後にReturnToTitleを呼び出す
            Invoke("ReturnToTitle", 2.0f);
        }
	}

    int CalcScore()
    {
        //ねじ子の走行距離をスコアとする
        return (int)nejiko.transform.position.z;
    }

    void ReturnToTitle()
    {
        //タイトルシーンに切り替え
        Application.LoadLevel("Title");
    }
}
