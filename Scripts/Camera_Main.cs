using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Main : MonoBehaviour
	{
		public Transform player;
		public Transform camera;

		[Header("Read only")]
		public Vector3 forward;
		public Vector3 right;
		public Quaternion relative_to_absolute;

		void Start() {
			forward = player.forward;
			right = Quaternion.FromToRotation(Vector3.forward, player.forward) * Vector3.right;
		}

		void Update() {
			/* Debug.DrawRay(transform.position, forward, Color.red); */
		}
	}
}
