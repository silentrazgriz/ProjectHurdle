using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {
	void OnTriggerEnter (Collider collider) {
		if (collider.transform.parent.tag == "ObstaclePrefab") {
			Destroy (collider.transform.parent.gameObject);
		}
	}
}
