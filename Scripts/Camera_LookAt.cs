using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules{
	public class Camera_LookAt : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		public Vector3 offset;
		public float easiness;

		void Update() {
			Quaternion lookrot = Quaternion.LookRotation(main.relative_to_absolute * offset + main.player.position
				       	- transform.position, Vector3.up);
			transform.rotation = Quaternion.Slerp(transform.rotation, lookrot, easiness*Time.deltaTime);
		}
	}
}
