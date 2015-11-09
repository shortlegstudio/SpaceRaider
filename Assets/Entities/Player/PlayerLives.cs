using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnDestroy() {
		SceneManager.GetInstance ().LoadLevel ("GameOver");
	}
}
