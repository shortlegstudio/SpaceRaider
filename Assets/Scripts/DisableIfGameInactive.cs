using UnityEngine;
using System.Collections;

public class DisableIfGameInactive : MonoBehaviour {
	public MonoBehaviour[] DisableList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool enable = GameController.GameReady ();

		foreach (MonoBehaviour b in DisableList) {
			b.enabled = enable;
		}
	}
}
