using UnityEngine;
using System.Collections;

/// <summary>
/// WaveSpawner manages how and when a wave should be spawned and what type of enemies to create
/// </summary>
public class WaveSpawner : MonoBehaviour {
	public GameObject enemyPrefab;

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
			if (positionSlot.childCount > 0) 
				return false;
		}
		return true;
	}


	/// <summary>
	/// Creates a new wave of enemies
	/// </summary>
	void SpawnWave() {
		foreach (Transform child in transform) {
			spawnEnemy (child);
		}
	}
	
	private void spawnEnemy(Transform position) {
		Debug.Log ("Spawn Enemy");
		GameObject go = Instantiate (enemyPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		
		//Set the enemy to the formation position
		//The second parameter (false) informs Unity to continue to use it's transform of 0,0,0 
		go.transform.SetParent (position, false);
	}
}
