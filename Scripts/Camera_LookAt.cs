using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules{
	public class Camera_LookAt : MonoBehaviour
	{
		/* This modules implements Smooth-LookAt */

		public CameraModules.Camera_Main main;
		public Vector3 offset;			// Looks At player + offset (offset is in relative coordinates)
		public float easiness;			// Smoothing parameter
		public bool fast;			// Check for no smoothing

		void Start() {
			print ("container.transform.rotation");
		}

		void Update() {
			if (fast) {
				main.container.LookAt(transform.rotation * offset + main.player.position);
				return;
			}

			Quaternion lookrot = Quaternion.LookRotation(transform.rotation * offset + main.player.position
				       	- main.container.position, transform.up);
			main.container.rotation = Quaternion.Lerp(main.container.rotation, lookrot, easiness*Time.deltaTime);
		}
	}
}
