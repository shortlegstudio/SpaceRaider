using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesTracker : MonoBehaviour {
	public int Lives;
	public Text LivesText;
	public int increment = 10000;
	public AudioClip ExtraLife;

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
			AudioSource.PlayClipAtPoint(ExtraLife, Vector3.zero, 0.4f);

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
