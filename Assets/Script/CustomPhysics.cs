using UnityEngine;
using System.Collections;

public class CustomPhysics : MonoBehaviour {
	public bool onGround = true;
	public float gravity = 0.2f;
	private Vector3 _gravityVector = Vector3.zero;
	private Vector3 _nextPosition = Vector3.zero;
	private Rigidbody _rigidbody;

	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		if (!onGround) {
			_gravityVector.y -= gravity;
		}
		_nextPosition = transform.position + _gravityVector;
		if (_nextPosition.y < 0f)
			_nextPosition.y = 0f;
		_rigidbody.MovePosition (_nextPosition);
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "Ground") {
			onGround = true;
			_rigidbody.useGravity = true;
		}
	}

	void OnCollisionExit (Collision collision) {
		if (collision.gameObject.tag == "Ground")
			onGround = false;
	}

	public void applyForce (Vector3 jumpForce) {
		_gravityVector = jumpForce;
		_rigidbody.useGravity = false;
	}
}
