// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace ShortLegStudio
{
	public static class ViewportHelpers
	{
		public static Vector3 GetBottomLeftBoundary(Vector3 position) {
			float distance = position.z - Camera.main.transform.position.z;
			return Camera.main.ViewportToWorldPoint(new Vector3(0,0, distance));
		}

		public static Vector3 GetTopRightBoundary(Vector3 position) {
			float distance = position.z - Camera.main.transform.position.z;
			return Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, distance));
		}
	}
}

