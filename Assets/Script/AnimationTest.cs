using UnityEngine;
using System.Collections;

public class AnimationTest : MonoBehaviour {
    private Animator anim;

	// Use this for initialization
	void Start () {
	   anim = GetComponent <Animator> ();
	}    
    public void Jump () {
        anim.SetTrigger ("isJump");
    }
}
