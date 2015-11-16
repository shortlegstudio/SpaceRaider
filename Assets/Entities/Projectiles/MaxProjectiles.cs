using UnityEngine;
using System.Collections;

/// <summary>
/// Simple script to limit how many projectiles are on a screen at a time
/// </summary>
public class MaxProjectiles : MonoBehaviour {
	public int maximum = 100;
	public AudioClip Sound;
	public float volume;

	// Use this for initialization
	void Start () {
		int currentCount = FindObjectsOfType<MaxProjectiles> ().Length;
		if (currentCount > maximum)
			Destroy (this.gameObject);
		else
			AudioSource.PlayClipAtPoint (Sound, this.transform.position, volume);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
