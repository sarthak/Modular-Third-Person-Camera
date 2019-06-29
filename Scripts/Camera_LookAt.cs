using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules{
	public class Camera_LookAt : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		public Vector3 offset;
		public float easiness;
		public bool fast;

		void Update() {
			if (fast) {
				main.container.LookAt(transform.rotation * offset + main.player.position);
				return;
			}

			Quaternion lookrot = Quaternion.LookRotation(transform.rotation * offset + main.player.position
				       	- main.container.position, transform.up);
			main.container.rotation = Quaternion.Slerp(main.container.rotation, lookrot, easiness*Time.deltaTime);
		}
	}
}
