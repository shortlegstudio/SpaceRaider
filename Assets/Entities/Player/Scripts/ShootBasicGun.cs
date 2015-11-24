using UnityEngine;
using System.Collections;

public class ShootBasicGun : MonoBehaviour {
	public GameObject LaserPrefab;
	public float fireLaserRate = 0.25f;
	public AudioClip LaserSound;
	public float LaserVolume = 0.5f;

	// Use this for initialization
	void Start () {
	
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
		AudioSource.PlayClipAtPoint (LaserSound, this.transform.position, LaserVolume);
	}
}
