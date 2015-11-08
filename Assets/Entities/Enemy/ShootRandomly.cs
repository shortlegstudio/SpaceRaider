﻿using UnityEngine;
using System.Collections;

public class ShootRandomly : MonoBehaviour {
	public float shootChance = 0.2f;
	public float shootDelay = 0.5f;
	public GameObject ProjectileBase;
	private float shotCooldown = 0f;

	// Update is called once per frame
	void Update () {
		shotCooldown -= Time.deltaTime;
		if (IsShooting ()) {
			FireShot();
		}

	}

	private void FireShot() {
		GameObject shot = Instantiate (ProjectileBase, this.transform.position, Quaternion.identity) as GameObject;
		shotCooldown = shootDelay;
	}

	private bool IsShooting() {
		return Random.value < shootChance && shotCooldown <=0;
	}
}
