using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour {
    public Movement player;
    public Animator animator;
    Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setPlayerInFrontOfEverything()
    {
        player.renderFrontOfEverything();
    }

    public void playGameOver()
    {
        canvas.enabled = true;
        animator.SetTrigger("GameOver");
    }
}
