using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text text = GetComponent<Text> ();
		text.text = string.Format ("SCORE: {0}", ScoreTracker.GetScoreString ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
