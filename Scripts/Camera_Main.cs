using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraModules {
	public class Camera_Main : MonoBehaviour
	{
		/* Main class for camera modules. All modules carry reference to this class.
		 * All centralized variables/methods should be part of this class and only this class */

		public Transform player;	// Reference to Player transform
		public Transform container;	// Reference to the direct sub-child 'container'
		public Transform camera;	// Reference to grand-child 'Main Camera'

		void Start() {
		}

		void Update() {
		}
	}
}
