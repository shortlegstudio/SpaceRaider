using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesTracker : MonoBehaviour {
	public int Lives;
	public Text LivesText;

	void Start () {
		Lives = 3;
		LivesText = GetComponent<Text> ();
	}

	public int LoseLife() {
		Lives--;
		LivesText.text = string.Format ("Lives: {0}", Lives);
		return Lives;
	}
}
