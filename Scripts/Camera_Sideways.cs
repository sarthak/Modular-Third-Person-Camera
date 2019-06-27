using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Sideways : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		public float responsiveness;

		private float root_distance;

		void Start() {
			root_distance = Vector3.Dot((main.player.position - transform.position), main.right);
		}

		void Update() {
			Vector3 right = main.right;
			float dist = Vector3.Dot((main.player.position - transform.position), right);

			if (Mathf.Approximately(dist, root_distance)) {
				return;
			} else {
				transform.Translate(right * responsiveness * (dist - root_distance) * Time.deltaTime,
							Space.World);
			}
		}
	}
}
