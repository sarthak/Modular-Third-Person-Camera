using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Orbit : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		public CameraModules.Camera_LookAt lookat;
		public Vector2 sensitivity;
		public float ymin;
		public float ymax;

		[Header ("Read only")]
		public Vector3 angles;

		void Start() {
			angles = Quaternion.FromToRotation(Vector3.forward, -main.container.localPosition).eulerAngles;
			lookat.fast = true;
		}

		void Update() {
			Vector2 movements = new Vector2(Input.GetAxis("Mouse X") * sensitivity.x,
							Input.GetAxis("Mouse Y") * sensitivity.y) * Time.deltaTime;
			if (movements == Vector2.zero)
				return;

			transform.Rotate(0, movements.x, 0);
			if (main.container.localPosition.y >= ymax && movements.y > 0)
				return;
			if (main.container.localPosition.y <= ymin && movements.y < 0)
				return;
			main.container.RotateAround(transform.position, transform.right, movements.y);
		}
	}
}
