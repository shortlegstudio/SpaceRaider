using UnityEngine;
using System.Collections;
using ShortLegStudio;

public class FormationController : MonoBehaviour {
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
	}
	
	// Update is called once per frame
	void Update () {
		moveFormation ();
	}

	private void moveFormation() {
		Vector3 movement = direction * formationSpeed * Time.deltaTime;
		transform.position += movement;

		//Validate position, reverse if invalid
		if (transform.position.x < minX)
			direction = Vector3.right;

		if (transform.position.x > maxX)
			direction = Vector3.left;
	}


	void OnDrawGizmos() {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, 0));
	}
}
