	using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour {
	private int score = 0;
	private const string SCORE_FORMAT = "{0}";
	private Text label;

	void Start() {
		label = GetComponent<Text> ();
		Reset ();
	}

	public void Reset() {
		score = 0;
		label.text = string.Format (SCORE_FORMAT, score.ToString("D7"));
	}

	public void ScorePoints(int points) {
		score += points;
		label.text = string.Format (SCORE_FORMAT, score.ToString("D7"));
	}

	public static ScoreTracker GetInstance() {
		return FindObjectOfType<ScoreTracker> ();
	}
}
