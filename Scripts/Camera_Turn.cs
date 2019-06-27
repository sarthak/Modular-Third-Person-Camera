using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Turn : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		public float responsiveness;

		void Update() {
			if (main.forward != main.player.forward) {
				float angle = Vector3.SignedAngle(main.forward, main.player.forward, main.player.up); 

				float delta = angle * responsiveness * Time.deltaTime;
				transform.RotateAround(main.player.position, main.player.up, delta);
				main.forward = Quaternion.AngleAxis(delta, main.player.up) * main.forward;

				main.relative_to_absolute = Quaternion.FromToRotation(Vector3.forward, main.player.forward);
				main.right =  main.relative_to_absolute * Vector3.right;
			}
		}
	}
}
