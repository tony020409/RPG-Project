using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    private PlayerMove move;
    private Animation animation;
	// Use this for initialization
	void Start () {
        move = this.GetComponent<PlayerMove>();
        animation = this.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (move.state == PlayerState.Moving)
        {
            PlayerAnim("Run");

        }
        else if (move.state == PlayerState.Idle) {
            PlayerAnim("Idle");
        }
	}

    void PlayerAnim(string animName) {
       animation.CrossFade(animName);
    }
}
