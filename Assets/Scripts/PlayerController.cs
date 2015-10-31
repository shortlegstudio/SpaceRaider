﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float strafeSpeed = 10.0f;
	public float minX = -10.0f;
	public float maxX = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float direction = GetHorizontalMove();
		if (direction != 0) {
			UpdateMovement(direction);
		}
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
		Vector3 newPos = transform.position + move;
		newPos.x = Mathf.Clamp (newPos.x, minX, maxX);
		transform.position = newPos;
	}
}
