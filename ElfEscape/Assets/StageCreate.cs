using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour {

    public GameObject wallPrefab;
    int wallX = 9;
    int wallZ = 9;

	// Use this for initialization
	void Start () {
        CreateWall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateWall()
    {
        //ループでwallXまで壁を生成する
        for(float f = -0.5f; f <= wallX; f++)
        {
            Instantiate(wallPrefab, new Vector3(f + 1, 0, -0.6f), Quaternion.identity);
            Instantiate(wallPrefab, new Vector3(f + 1, 0, wallX + 1.5f), Quaternion.identity);
        }

        for (float f = -0.5f; f <= wallZ; f++)
        {
            Instantiate(wallPrefab, new Vector3(-0.6f, 0, f + 1), Quaternion.identity);
            Instantiate(wallPrefab, new Vector3(wallZ + 1.5f, 0, f + 1), Quaternion.identity);
        }
    }
}
