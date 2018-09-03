using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_screen : MonoBehaviour {

    public GameObject logo;
    public  int scene_cont;

	void Start () {
        StartCoroutine(SplashScreen());
	}
	
    IEnumerator SplashScreen()
    {
        yield return new WaitForSeconds(0.5f);
        logo.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(scene_cont);
    }

}
