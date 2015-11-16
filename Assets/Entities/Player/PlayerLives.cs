using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour {
	public GameObject Player;
	LivesTracker tracker;

	// Use this for initialization
	void Start () {
		tracker = GameObject.FindObjectOfType<LivesTracker> ();

	}

	void OnDestroy() {
		int lives = tracker.LoseLife ();
		GameController.PlayerDied (lives);
	}
}
