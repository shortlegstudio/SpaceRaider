using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script that moves straight line along some direction
/// </summary>
public class MoveStraight : MonoBehaviour {
	public Vector3 moveDirection;
	public float moveSpeed;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += moveDirection * moveSpeed * Time.deltaTime;
	}
}
