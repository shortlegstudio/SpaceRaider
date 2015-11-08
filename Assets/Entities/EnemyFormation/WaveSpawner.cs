using UnityEngine;
using System.Collections;

/// <summary>
/// WaveSpawner manages how and when a wave should be spawned and what type of enemies to create
/// </summary>
public class WaveSpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float enemySpawnDelay = 0.75f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (IsEmpty ()) {
			SpawnWave ();
		}
			
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
	/// </summary>
	void SpawnWave() {
		Transform child = NextFreePosition ();
		if (child) {
			spawnEnemy (child);
		}

		if (NextFreePosition ()) {
			Invoke ("SpawnWave", enemySpawnDelay);
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

	
	private void spawnEnemy(Transform position) {
		Debug.Log ("Spawn Enemy");
		GameObject go = Instantiate (enemyPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		
		//Set the enemy to the formation position
		//The second parameter (false) informs Unity to continue to use it's transform of 0,0,0 
		go.transform.SetParent (position, false);
	}
}
