using UnityEngine;
using System.Collections;
using System.Linq;

public class DiveBomb : MonoBehaviour {
	public float diveBombFrequency;
	public AudioClip diveBombSound;
	public float diveBombVolume = 0.5f;
	public static int MaximumDivers = 3;
	private Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator> ();	
	}

	void Update() {
		if (IsIdle ()) {
			//Make sure this is false when we are idle
			_animator.SetBool("DiveBombAttack", false);
			//Dive bomb?
			if (Random.value < Time.deltaTime * diveBombFrequency
			    && DivingCount () < MaximumDivers) {
				LaunchDiveBomb();
			}
		}
	}

	bool IsIdle() {
		return _animator.GetCurrentAnimatorStateInfo(0).IsName ("Idle");
	}

	bool IsDiving() {
		return _animator.GetBool ("DiveBombAttack");
	}

	void LaunchDiveBomb() {
		_animator.SetBool ("DiveBombAttack", true);
		_animator.SetFloat ("AttackMethod", Random.value);
		AudioSource.PlayClipAtPoint (diveBombSound, this.transform.position, diveBombVolume);
	}

	/// <summary>
	/// Count the number of objects that are currently diving
	/// </summary>
	/// <returns>The count.</returns>
	static int DivingCount() {
		DiveBomb[] dbs = GameObject.FindObjectsOfType<DiveBomb> ();
		return dbs.Count (db => db.IsDiving());
	}
}
