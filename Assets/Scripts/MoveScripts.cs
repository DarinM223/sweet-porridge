using UnityEngine;
using System.Collections;

public static class MoveScripts {
	/**
	 * Function for object1 to rotate to face object2
	 * @param {GameObject} object1 the object that rotates
	 * @param {GameObject} object2 the object to rotate to
	 */
	public static void RotateToFace(Transform object1, Transform object2) {
		Quaternion targetRotation = Quaternion.LookRotation (object2.position - object1.position);
		var str = Mathf.Min (1 * Time.deltaTime, 1);
		object1.rotation = Quaternion.Lerp (object1.rotation, targetRotation, str);
	}
}
