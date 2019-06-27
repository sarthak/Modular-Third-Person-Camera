using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Follow : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		public float responsiveness;
		public Vector3 up = Vector3.up;

		private Vector3 root_distance;

		void Start() {
			root_distance = Vector3.ProjectOnPlane(main.player.position - transform.position, up);
		}

		void Update() {
			Vector3 dist = Vector3.ProjectOnPlane(main.player.position - transform.position, up);

			if (dist == root_distance) {
				return;
			} else {
				transform.Translate((dist - root_distance) * responsiveness * Time.deltaTime, Space.World);
			}
		}
	}
}
