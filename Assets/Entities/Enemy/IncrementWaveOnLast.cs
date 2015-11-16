using UnityEngine;
using System.Collections;

public class IncrementWaveOnLast : MonoBehaviour {

	void OnDestroy() {
		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			GameController.NextWave();
		}
	}
}
