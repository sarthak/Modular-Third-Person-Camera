using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Turn : MonoBehaviour
	{
		/* Module which makes camera follow the player's rotation to,
		 * that is, turn with the player */

		public CameraModules.Camera_Main main;
		public float responsiveness;

		void Start() {
			print ("root.rotation");
		}

		void Update() {
			if (transform.rotation != main.player.rotation) {
				Quaternion final = Quaternion.FromToRotation(Vector3.forward, main.player.forward);
				transform.rotation = Quaternion.Lerp(transform.rotation, final, responsiveness * Time.deltaTime);;
			}
		}
	}
}
