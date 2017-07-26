using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour {

    public GameObject[] icons;

    //ライフに応じてスクリプトを出し分ける
    //(渡されたlifeの値に応じて、登録されたライフアイコンの表示と非表示を切り替える)
    public void updateLife(int life)
    {
        //i = 0から、アイコンの数(icons.length)まで、１ずつ増えていく
        for(int i = 0;i < icons.Length; i++)
        {
            //SetActive→ゲームオブジェクトの有効・無効を切り替えることができる
            if (i < life) icons[i].SetActive(true);
            else icons[i].SetActive(false);
        }
    }
}
