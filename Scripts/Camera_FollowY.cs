using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_FollowY : MonoBehaviour
	{
		public CameraModules.Camera_Main main;
		[Range(0, 1f)]
		public float y_relax = 1f;

		Vector3 player_prev;

		void Start() {
			print ("root.transform.position.y");
			player_prev = main.player.position;
		}

		void Update() {
			Vector3 delta = Vector3.Project((main.player.position - player_prev), main.player.up);
			if (delta == Vector3.zero)
				return;
			transform.position += delta * y_relax;
			player_prev = main.player.position;
		}

	}
}
