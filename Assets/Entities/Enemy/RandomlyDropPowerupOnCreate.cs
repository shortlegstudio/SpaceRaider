using UnityEngine;
using System.Collections;
using ShortLegStudio;

public class RandomlyDropPowerupOnCreate : MonoBehaviour {
	public GameObject[] powerUps;
	public float chance = 0.1f;

	void Start() {
		if (Random.value < chance) {
			Instantiate(powerUps.ChooseOne(), transform.position, Quaternion.identity);
		}
	}
}
