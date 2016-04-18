using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float jumpForce;
	public CustomPhysics customPhysics;
	public LevelManager levelManager;
	private Animator _animator;
	private bool _jumpInput = false;

	void Start () {
		_animator = GetComponent<Animator> ();
	}

	void Update () {
#if UNITY_EDITOR
		if (Input.GetKeyUp (KeyCode.Space) && customPhysics.onGround && !_jumpInput) {
			_jumpInput = true;
		}
#elif UNITY_ANDROID || UNITY_IOS
		if (Input.touchCount > 0 && customPhysics.onGround && !_jumpInput) {
			_jumpInput = true;
		}
#endif
	}

	void FixedUpdate () {
		if (_jumpInput) {
			customPhysics.applyForce (new Vector3 (0f, jumpForce, 0f));
			_animator.SetTrigger ("isJump");
			_jumpInput = false;
		}
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.tag == "Score") {
			levelManager.addScore ();
		}
	}
}
