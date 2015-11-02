using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject LaserPrefab;
	public float strafeSpeed = 10.0f;
	public float fireLaserRate = 0.25f;

	// Update is called once per frame
	void Update () {
		float direction = GetHorizontalMove();
		if (direction != 0) {
			UpdateMovement(direction);
		}


		HandleWeapons ();

	}


	/// <summary>
	/// Deals with the inputs and operations around firing shots
	/// </summary>
	private void HandleWeapons() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("FireLaser", 0.00001f, fireLaserRate);
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("FireLaser");
		}
	}

	/// <summary>
	/// Creates a new Laser entity
	/// </summary>
	private void FireLaser() {
		Instantiate (LaserPrefab, transform.position, Quaternion.identity); 
	}

	/// <summary>
	/// Figure out what direction we are moving
	/// </summary>
	/// <returns>The horizontal move.</returns>
	private float GetHorizontalMove() {
		return Input.GetAxisRaw ("Horizontal");
	}

	/// <summary>
	/// Handle movement for player ship
	/// </summary>
	/// <param name="directionX">Direction x.</param>
	private void UpdateMovement(float directionX) {
		float movementX = directionX * strafeSpeed * Time.deltaTime;
		Vector3 move = new Vector3 (movementX, 0, 0);
		transform.position += move;
	}
}
