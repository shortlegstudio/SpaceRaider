using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public Text ReadyPlayerOneText;
	public float ReadyPlayerOneDelay;
	public bool GameIsReady = false;

	public static GameController GetInstance() {
		return GameObject.FindObjectOfType<GameController> ();
	}

	public static void PlayerOneSpawning() {
		GetInstance ().ShowPlayerOneText ();
	}

	public static void PlayerDied() {
		GetInstance ().GameIsReady = false;
	}

	void ShowPlayerOneText() {
		ReadyPlayerOneText.enabled = true;
		Invoke ("HidePlayerOneText", ReadyPlayerOneDelay);
		GameIsReady = false;
	}

	void HidePlayerOneText() {
		ReadyPlayerOneText.enabled = false;
		GameIsReady = true;
	}


	public static bool GameReady() {
		return GetInstance().GameIsReady;
	}
}
