using UnityEngine;
using System.Collections;

public class TakesDamage : MonoBehaviour {
	public GameObject DeathClip;
	public float Health = 10.0f;
	public int Points = 0;


	void OnTriggerEnter2D(Collider2D other) {
		Projectile missile = other.GetComponent<Projectile> ();
		if (missile) {
			TakeDamage (missile.GetDamage ());
			missile.Hit ();
		} else {
			//If hitting another solid object take full damage
			TakesDamage solidObject = other.GetComponent<TakesDamage>();
			if (solidObject) {
				TakeDamage(this.Health);
			}
		}
	}


	private void TakeDamage(float damage) {
		Debug.Log ("Taking Damage");
		this.Health -= damage;

		if (Health <= 0) {
			DestroyEntity();
		}
	}


	/// <summary>
	/// When an entity is destroyed because it's health is zero, execute relevant commands
	/// </summary>
	private void DestroyEntity() {
		//Create death clip object
		GameObject clip = Instantiate (DeathClip, this.transform.position, Quaternion.identity) as GameObject;

		//Show points if available
		if (Points != 0)
			clip.GetComponentInChildren<TextMesh> ().text = Points.ToString ();

		//Remove Game Object
		Destroy (this.gameObject);

		//Add Points for destroying it
		ScoreTracker.GetInstance ().ScorePoints (Points);
	}
}
