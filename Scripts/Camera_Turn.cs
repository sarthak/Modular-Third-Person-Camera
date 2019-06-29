using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Turn : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		public float responsiveness;

		void Update() {
			if (transform.rotation != main.player.rotation) {
				Quaternion final = Quaternion.FromToRotation(Vector3.forward, main.player.forward);
				transform.rotation = Quaternion.Lerp(transform.rotation, final, responsiveness * Time.deltaTime);;
			}
		}
	}
}
