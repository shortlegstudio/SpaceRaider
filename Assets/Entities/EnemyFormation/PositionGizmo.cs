using UnityEngine;
using System.Collections;

public class PositionGizmo : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere (this.transform.position, 0.5f);
	}
}
