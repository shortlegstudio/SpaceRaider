using UnityEngine;
using System.Collections;

public class DiveBomb : MonoBehaviour {
	public float diveBombFrequency;
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
			if (Random.value < Time.deltaTime * diveBombFrequency) {
				LaunchDiveBomb();
			}
		}

	}

	bool IsIdle() {
		return _animator.GetCurrentAnimatorStateInfo(0).IsName ("Idle");
	}

	void LaunchDiveBomb() {
		_animator.SetBool ("DiveBombAttack", true);
		_animator.SetFloat ("AttackMethod", Random.value);
	}
}
