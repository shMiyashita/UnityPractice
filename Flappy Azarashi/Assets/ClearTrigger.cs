using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour {

	GameObject gameController;

	// Use this for initialization
	void Start ()
	{
		//ゲーム開始時にGameControllerをFindしておく
		gameController = GameObject.FindWithTag("GameController");
	}

	//トリガーからExitしたらクリアしたとみなす
	private void OnTriggerExit2D(Collider2D other)
	{
		gameController.SendMessage("IncreaseScore");
	}
}
