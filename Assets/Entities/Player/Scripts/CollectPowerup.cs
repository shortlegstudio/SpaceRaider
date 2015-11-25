using UnityEngine;
using System.Collections;

public class CollectPowerup : MonoBehaviour {
	private ShootBasicGun shoot;

	// Use this for initialization
	void Start () {
		shoot = GetComponentInChildren<ShootBasicGun> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("PowerUp")) {
			Debug.Log ("Caught Powerup");
			shoot.UpgradeWeapon();
			Destroy (other.gameObject);
		}
	}
}
