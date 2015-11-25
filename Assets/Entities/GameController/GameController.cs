using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public Text ReadyPlayerOneText;
	public float MessageDelay;
	public Text WaveText;
	public bool GameIsReady = false;
	public int WaveNumber = 0;
	public float volume = 0.5f;
	public GameObject player;
	public AudioClip WaveSpawned;
	private float LastWaveCheck = 0;
	private float MinTimeBetweenCheck = 1f;


	public static GameController GetInstance() {
		return GameObject.FindObjectOfType<GameController> ();
	}

	public static void PlayerOneSpawning() {
		GameController instance = GetInstance ();
		if (instance)
			instance.ShowPlayerOneText ();
		//NextWave ();
	}

	public static void NextWave() {
		GameController instance = GetInstance ();
		if (instance)
			instance.ShowWaveText ();
	}

	public static void PlayerDied(int lives) {
		if (lives <= 0) {
			SceneManager.GetInstance ().Invoke ("LoadNextLevel", 3);
		} else {
			GetInstance().Invoke ("SpawnPlayer", 3);
		}
	}

	void Start() {
		NextWave ();
	}

	void Update() {
		if (GameIsReady && GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			LastWaveCheck += Time.deltaTime;
			if (LastWaveCheck > MinTimeBetweenCheck) {
				NextWave ();
			}
		} else {
			LastWaveCheck = 0;
		}
	}

	void SpawnPlayer() {
		Instantiate (player);
	}

	void ShowWaveText() {
		WaveNumber++;
		WaveText.text = "Wave " + WaveNumber;
		WaveText.enabled = true;
		Invoke ("HideWaveText", MessageDelay);
		GameIsReady = false;
	}

	void HideWaveText() {
		WaveText.enabled = false;
		GameIsReady = true;
		AudioSource.PlayClipAtPoint (WaveSpawned, this.transform.position, volume);
	}

	void ShowPlayerOneText() {
		ReadyPlayerOneText.enabled = true;
		Invoke ("HidePlayerOneText", MessageDelay);
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
