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
	private int MaxLevel = 10;
	private float offsetX = 0;
	private int extraLaserLevel = 2;

	void Start() {
		SpriteRenderer render = GetComponentInParent<SpriteRenderer> ();
		offsetX = render.sprite.pivot.x / render.sprite.pixelsPerUnit;
	}


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
		int laserCounts = WeaponLevel / extraLaserLevel;

		//Player has earned extra lasers
		if (laserCounts > 0 && WeaponLevel < MaxLevel) {
			float xInc = (offsetX * 2) / laserCounts;
			Vector3 startPosition = transform.position;
			startPosition.x -= offsetX; //Farthest left
			Debug.Log ("xIncrement: " + xInc);
			for (int index=0; index <= WeaponLevel / extraLaserLevel; index++) {
				CreateProjectile (startPosition);
				startPosition.x += xInc;
			}
		} else if (WeaponLevel == MaxLevel) {
			//Make a giant laser shot
			CreateMassiveProjectile(transform.position);

		} else {
			//just create a single laser shot
			CreateProjectile (transform.position);
		}

		AudioSource.PlayClipAtPoint (LaserSound, this.transform.position, LaserVolume);
	}

	private void CreateProjectile(Vector3 pos) {
		GameObject laser = (GameObject)Instantiate (LaserPrefab, pos, Quaternion.identity);
		Projectile proj = laser.GetComponent<Projectile> ();
		proj.Damage += DamagePerLevel * WeaponLevel;
		Vector3 scale = Vector3.one;
		scale.y += 0.05f * WeaponLevel;
		scale.x += 0.025f * WeaponLevel;
		proj.transform.localScale = scale;
	}

	private void CreateMassiveProjectile(Vector3 pos) {
		GameObject laser = (GameObject)Instantiate (LaserPrefab, pos, Quaternion.identity);
		Projectile proj = laser.GetComponent<Projectile> ();
		proj.Damage += DamagePerLevel * WeaponLevel;
		Vector3 scale = Vector3.one;
		scale.y += 1;
		scale.x += 3;
		proj.transform.localScale = scale;
	}

	public void UpgradeWeapon() {
		WeaponLevel++;
		WeaponLevel = Mathf.Clamp (WeaponLevel, 0, MaxLevel);
		Debug.LogFormat ("Weapon Level: {0}", WeaponLevel);
	}
}
