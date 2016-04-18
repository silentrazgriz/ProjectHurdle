using UnityEngine;
using System.Collections;

public class ContinuousMovement : MonoBehaviour {
	public float multiplier;
	public Vector3 movementSpeed;

	void Update () {
		transform.position += movementSpeed * Time.deltaTime * multiplier;
	}
}
