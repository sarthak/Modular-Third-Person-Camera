using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Orbit : MonoBehaviour
	{
		/* This module implements Camera Orbit motion */
		/* Use mouse to orbit the camera around player,
		 * note that : this does not, by itself, rotate player.
		 * To have player rotated by rotation of camera, set the player's rotation
		 * from player's script to be equal to rotation of camera-root */

		public CameraModules.Camera_Main main;
		public Vector2 sensitivity;		// Sensitivity of orbiting
		public float ymin;			// min possible y-coordinate during orbit
		public float ymax;			// max possible y-coord during orbit

		void Start() {
			print ("root.transform.rotation.y");
			print ("container.transform.rotation");
			print ("container.transform.localPosition");
		}
		void Update() {
			Vector2 movements = new Vector2(Input.GetAxis("Mouse X") * sensitivity.x,
							Input.GetAxis("Mouse Y") * sensitivity.y) * Time.deltaTime;
			if (movements == Vector2.zero)
				return;

			//X-Rotation is carried out by rotating root itself
			transform.Rotate(0, movements.x, 0);
			if (main.container.localPosition.y >= ymax && movements.y > 0)
				return;
			if (main.container.localPosition.y <= ymin && movements.y < 0)
				return;
			
			//But Y-Rotating is carried by only rotating container about root
			main.container.RotateAround(transform.position, transform.right, movements.y);
		}
	}
}
