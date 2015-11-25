using UnityEngine;
using System.Collections;

public class ShootBasicGun : MonoBehaviour {
	public GameObject LaserPrefab;
	public float fireLaserRate = 0.25f;
	public AudioClip LaserSound;
	public float LaserVolume = 0.5f;
	public float DamagePerLevel = 25f;
	public float FireRatePerLevel = 0.01f;
	private int WeaponLevel = 0;

	// Update is called once per frame
	void Update () {
		HandleWeapons ();
	}

	/// <summary>
	/// Deals with the inputs and operations around firing shots
	/// </summary>
	private void HandleWeapons() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating("FireLaser", 0.00001f, fireLaserRate - (FireRatePerLevel * WeaponLevel));
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("FireLaser");
		}
	}
	
	/// <summary>
	/// Creates a new Laser entity
	/// </summary>
	private void FireLaser() {
		GameObject laser = (GameObject)Instantiate (LaserPrefab, transform.position, Quaternion.identity);
		Projectile proj = laser.GetComponent<Projectile> ();
		proj.Damage += DamagePerLevel * WeaponLevel;
		Vector3 scale = Vector3.one;
		scale.y += 0.05f * WeaponLevel;
		scale.x += 0.025f * WeaponLevel;
		proj.transform.localScale = scale;
		AudioSource.PlayClipAtPoint (LaserSound, this.transform.position, LaserVolume);
	}

	public void UpgradeWeapon() {
		WeaponLevel++;
		Debug.LogFormat ("Weapon Level: {0}", WeaponLevel);
	}
}
