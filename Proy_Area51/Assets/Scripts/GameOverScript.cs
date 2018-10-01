using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    public Movement player;
    public Animator animator;
    public Text text;
    public string scene;
    Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
        text.enabled = false;

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
        StartCoroutine(BotonPlayAgain());
    }
    public void PlayAgain()
    {
        
        SceneManager.LoadScene(scene);

    }

    IEnumerator BotonPlayAgain()
    {
        yield return new WaitForSeconds(4f);
        text.enabled = true;
        animator.SetBool("PlayAgain",true);
    }

}
