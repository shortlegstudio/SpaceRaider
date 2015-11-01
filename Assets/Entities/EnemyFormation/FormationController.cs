using UnityEngine;
using System.Collections;
using ShortLegStudio;

public class FormationController : MonoBehaviour {
	public GameObject enemyPrefab;
	public float formationSpeed = 10.0f;
	public float height;
	public float width;

	private Vector3 direction = Vector3.left;
	private float minX;
	private float maxX;

	// Use this for initialization
	void Start () {

		minX = ViewportHelpers.GetBottomLeftBoundary (transform.position).x + width / 2;
		maxX = ViewportHelpers.GetTopRightBoundary (transform.position).x - width / 2;

		foreach (Transform child in transform) {
			spawnEnemy (child);
		}
	}
	
	// Update is called once per frame
	void Update () {
		moveFormation ();
	}

	private void moveFormation() {
		Vector3 movement = direction * formationSpeed * Time.deltaTime;
		transform.position += movement;

		//Validate position, reverse if invalid
		if (transform.position.x < minX || transform.position.x > maxX)
			direction.x *= -1;
	}

	private void spawnEnemy(Transform position) {
		Debug.Log ("Spawn Enemy");
		GameObject go = Instantiate (enemyPrefab, Vector3.zero, Quaternion.identity) as GameObject;

		//Set the enemy to the formation position
		//The second parameter (false) informs Unity to continue to use it's transform of 0,0,0 
		go.transform.SetParent (position, false);
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}
}
