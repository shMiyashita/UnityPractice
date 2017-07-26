using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {

    const int StageTipSize = 30;

    int currentTipIndex;

    //ターゲットキャラクターの指定
    //*inspecterウインドウで適用する
    public Transform character;
    //ステージチッププレファブ配列
    //→生成するステージチップのプレファブを複数指定する。この配列の中から、生成するステージチップがランダムに選ばれる
    //*inspecterウインドウで適用する
    public GameObject[] stageTips;
    //自動生成開始インデックス→ゲームスタート時にどのインデックスからステージチップの自動生成を開始するかを指定する
    //→0からはじめればいいんちゃうん？
    //*inspecterウインドウで適用する
    public int startTipIndex;
    //生成先読み個数→現在のキャラクターの位置から何個先のステージチップを自動的に生成しておくかを指定する
    //*inspecterウインドウで適用する
    public int preInstantiate;
    //生成済みステージチップ保持リスト
    //List<型>で<型>のリストを作成する→GameObject型でリスト作成
    public List<GameObject> generatedStageList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        //初期化処理
        currentTipIndex = startTipIndex - 1;//現在のステージチップインデックスは、スタートチップインデックスから-1した値
        UpdateStage(preInstantiate);//ステージチップをあらかじめ作成する(インスタンス化)
	}
	
	// Update is called once per frame
	void Update () {
        //キャラクターの位置から現在のステージチップのインデックスを計算
        int charaPositionIndex = (int)(character.position.z / StageTipSize);

        //次のステージチップに入ったらステージの更新処理を行う
        //→ステージチップが足りなくなる前にステージを更新していく
        if(charaPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
	}

    //指定のIndexまでのステージチップを生成して、管理下に置く
    void UpdateStage(int toTipIndex)//引数→いくつ先までステージチップを作成しとくか？
    {
        if (toTipIndex <= currentTipIndex) return;//現在のチップが先のチップ数より大きかったらステージアップデートは行わない

        //指定のステージチップまでを作成
        //現在のステージチップインデックス+1から始めて、目標のステージチップ数まで+1ずつしていく
        for (int i = currentTipIndex + 1;i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);

            //生成したステージチップを管理リストに追加し
            //generatedStageList→管理リスト
            generatedStageList.Add(stageObject);
        }

        //ステージ保持上限内になるまで古いステージを削除
        //ステージ数と目標ステージ数は同じになるようにしておく？
        while (generatedStageList.Count > preInstantiate + 2) DestroyOldStage();

        currentTipIndex = toTipIndex;
    }
    
    //指定のIndex位置にStageオブジェクトをランダムに生成
    //Index位置って何？→ステージチップの長さをかけた先にステージを生成していくんかな･･･
    GameObject GenerateStage (int tipIndex)
    {
        //制しえに用いるプレファブをランダムに選択する
        int nextStageTip = Random.Range(0, stageTips.Length);

        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip],
            new Vector3(0, 0, tipIndex * StageTipSize),
            Quaternion.identity
        );

        return stageObject;
    }

    //一番古いステージを削除
    void DestroyOldStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }


}


