using UnityEngine;
using System.Collections;

public class RandomlyDropPowerupOnCreate : MonoBehaviour {
	public GameObject powerUp;
	public float chance = 0.1f;

	void Start() {
		if (Random.value < chance) {
			Instantiate(powerUp, transform.position, Quaternion.identity);
		}
	}
}
