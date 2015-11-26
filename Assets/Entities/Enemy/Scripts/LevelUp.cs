using UnityEngine;
using System.Collections;

public class LevelUp : MonoBehaviour {
	public int baseWave = 0;
	public Sprite[] images;
	public float healthPerLevel = 0;
	public int levelsPerImage = 5;
	public int level;

	// Use this for initialization
	void Start () {
		//Figure out our level
		level = GameController.GetInstance ().WaveNumber - baseWave;
		if (level < 0)
			level = 0;

		//Upgrade unit on creation
		TakesDamage health = GetComponent<TakesDamage> ();
		health.Health += level * healthPerLevel;

		//Switch image
		int image = level / levelsPerImage;
		if (image >= images.Length) 
			image = images.Length - 1;

		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = images [image];
	}

}
