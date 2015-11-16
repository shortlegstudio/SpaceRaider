using UnityEngine;
using System.Collections;

/// <summary>
/// WaveSpawner manages how and when a wave should be spawned and what type of enemies to create
/// </summary>
public class WaveSpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float enemySpawnDelay = 0.75f;
	public float spawnVolume;
	public int spawnGrouping = 1;
	public int waveActivated = 0;
	public int waveDisabled = 10000;
	public int waveSpawned = -1;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (IsEmpty () && ReadyForWave()) {
			SpawnWave ();
		}
			
	}

	/// <summary>
	/// This looks at the active wave and the last wave spawned by this formation and decides
	/// whether it is time to spawn another one
	/// </summary>
	/// <returns><c>true</c>, if for wave was readyed, <c>false</c> otherwise.</returns>
	private bool ReadyForWave() {
		int currentWave = GameController.GetInstance ().WaveNumber;

		//We already spawned for this level, ignore
		if (currentWave == waveSpawned)
			return false;

		return currentWave >= waveActivated && currentWave < waveDisabled;
	}

	/// <summary>
	/// Checks for whether the formation has any enemies in it
	/// </summary>
	/// <returns><c>true</c> if this instance is empty; otherwise, <c>false</c>.</returns>
	public bool IsEmpty() {
		foreach (Transform positionSlot in transform) {
			//If we find a single enemy, we must not be empty
			if (!IsPositionEmpty (positionSlot)) 
				return false;
		}
		return true;
	}


	/// <summary>
	/// Creates a new wave of enemies
	/// 
	/// It queues all enemy spawning through Invokes to actually create enemies
	/// This allows the wave to get fully spawned and not be continuously spawning
	/// if player eliminates an enemy during the entry phase
	/// </summary>
	void SpawnWave() {
		waveSpawned = GameController.GetInstance ().WaveNumber;
		for (int spawnIndex = 0; spawnIndex < transform.childCount; spawnIndex+= spawnGrouping) {
			for (int i = 0; i < spawnGrouping; i++)
				Invoke ("SpawnEnemy", enemySpawnDelay * spawnIndex);
		}
	}

	/// <summary>
	/// Finds the next available position in the formation
	/// </summary>
	/// <returns>The free position.</returns>
	Transform NextFreePosition() {
		foreach (Transform positionSlot in transform) {
			if (IsPositionEmpty(positionSlot) )
				return positionSlot;
		}
		return null;
	}

	/// <summary>
	/// Checks the position for children 
	/// </summary>
	/// <returns><c>true</c> if this position is empty; otherwise, <c>false</c>.</returns>
	/// <param name="position">Position.</param>
	bool IsPositionEmpty(Transform position) {
		return position.childCount == 0;
	}

	
	private void SpawnEnemy() {
		Transform position = NextFreePosition ();

		//If we couldn't find a position than exit out
		if (position == null)
			return;

		Debug.Log ("Spawn Enemy");
		GameObject go = Instantiate (enemyPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		
		//Set the enemy to the formation position
		//The second parameter (false) informs Unity to continue to use it's transform of 0,0,0 
		go.transform.SetParent (position, false);

		//Figure out if we want to enter on the left or right
		Animator animator = go.GetComponent<Animator> ();
		animator.SetFloat ("ArrivalDirection", Random.value);
	}
}
