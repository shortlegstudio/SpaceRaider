using UnityEngine;
using System.Collections;

public class TakesDamage : MonoBehaviour {
	public float Health = 10.0f;

	void OnTriggerEnter2D(Collider2D other) {
		Projectile missile = other.GetComponent<Projectile> ();
		if (missile) {
			TakeDamage(missile.GetDamage ());
			missile.Hit();
		}
	}

	private void TakeDamage(float damage) {
		Debug.Log ("Taking Damage");
		this.Health -= damage;

		if (Health <= 0) {
			Destroy (this.gameObject);
		}

	}
}
