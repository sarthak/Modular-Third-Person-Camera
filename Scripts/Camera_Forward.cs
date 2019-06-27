using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Forward : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		public float responsiveness;

		private float root_distance;

		void Start() {
			root_distance = Vector3.Dot((main.player.position - transform.position), main.forward);
		}

		void Update() {
			Vector3 forward = main.forward;
			float dist = Vector3.Dot((main.player.position - transform.position), forward);

			if (Mathf.Approximately(dist, root_distance)) {
				return;
			} else {
				transform.Translate(forward * responsiveness * (dist - root_distance) * Time.deltaTime,
							Space.World);
			}
		}

	}
}
