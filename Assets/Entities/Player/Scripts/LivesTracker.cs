using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesTracker : MonoBehaviour {
	public int Lives;
	public Text LivesText;
	public int increment = 10000;

	private int nextLife = 0;

	void Start () {
		Lives = 3;
		LivesText = GetComponent<Text> ();
		nextLife = increment;
	}

	void Update() {
		if (ScoreTracker.GetScore () > nextLife) {
			Lives++;
			RefreshText ();
			nextLife += increment;
		}
	}

	public int LoseLife() {
		Lives--;
		RefreshText ();
		return Lives;
	}

	private void RefreshText() {
		LivesText.text = string.Format ("Lives: {0}", Lives);
	}
}
