using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotBall : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {

        //出現後一定時間で自動的に消滅させる
        Destroy(gameObject, 2.0f);
		
	}
	
	// Update is called once per frame
	void Update () {

        //球を前進させる
        transform.position += transform.forward * Time.deltaTime * 100;

    }

    //他のcollision,rigidbodyと接触したら呼び出される
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            Destroy(gameObject); //.gameObject=自分自身
            Instantiate(explosion, transform.position, transform.rotation);

            //あたってるかテスト
            Debug.Log("cube hit OnCollisionEnter with " + collision.gameObject);
        }

    }

}
