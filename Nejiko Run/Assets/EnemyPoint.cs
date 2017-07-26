using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// gitコミットテスト

/// <summary>
/// EnemyPointスクリプトの基本機能は、指定されたプレファブを自分自身と同じ位置に生成するというもの
/// これにより、このEnemyPointをステージに配置するだけで、どの敵をどの位置に生成するかを指定できる。
/// </summary>
public class EnemyPoint : MonoBehaviour {

    public GameObject prefab;

	// Use this for initialization
	void Start () {
        //プレファブを同ポジションに生成
        GameObject go = (GameObject)Instantiate(
            prefab,
            Vector3.zero,
            Quaternion.identity
        );

        //一緒に削除されるように生成した敵オブジェクトを子に設定
        go.transform.SetParent(transform, false);
	}

    //ステージエディット中のためシーンにキズモを表示
    private void OnDrawGizmos()
    {
        //ギズモの底辺が地面と同じ高さになるようにオフセットを設定
        Vector3 offset = new Vector3(0, 0.5f, 0);

        //球を表示
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + offset, 0.5f);

        //プレファブ名のアイコンを表示
        if (prefab != null)
            Gizmos.DrawIcon(transform.position + offset, prefab.name, true);
    }
}
