using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Follow : MonoBehaviour
	{
		/* This module implements smooth-follow for camera */

		public CameraModules.Camera_Main main;
		public float responsiveness;		// How fast the camera catches up to player

		private Vector3 up = Vector3.up;

		void Start() {
			up = transform.up;

			Debug.Log("root.transform.position.xy");
		}

		void Update() {
			Vector3 dist = Vector3.ProjectOnPlane(main.player.position - transform.position, up);

			if (dist == Vector3.zero) {
				return;
			} else {
				transform.Translate((dist) * responsiveness * Time.deltaTime, Space.World);
			}
		}
	}
}
