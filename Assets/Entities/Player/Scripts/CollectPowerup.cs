using UnityEngine;
using System.Collections;

public class CollectPowerup : MonoBehaviour {
	private ShootBasicGun shoot;
	public AudioClip CaughtSound;
	public float volume = 0.5f;
	public GameObject ShieldPrefab;

	// Use this for initialization
	void Start () {
		shoot = GetComponentInChildren<ShootBasicGun> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("PowerUp")) {
			Debug.Log ("Caught Powerup");
			shoot.UpgradeWeapon();
			Destroy (other.gameObject);
			AudioSource.PlayClipAtPoint(CaughtSound, gameObject.transform.position);
		} else if (other.CompareTag("PowerUp_Shield")) {
			if (GetComponentInChildren<Shield>() == null) {
				GameObject shield = Instantiate(ShieldPrefab, Vector3.zero, Quaternion.identity) as GameObject;
				shield.transform.SetParent (transform, false);
				Destroy (other.gameObject);
				AudioSource.PlayClipAtPoint(CaughtSound, gameObject.transform.position);
			}
		}
	}
}
