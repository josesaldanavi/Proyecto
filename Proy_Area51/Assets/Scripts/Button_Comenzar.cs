using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Comenzar : MonoBehaviour {
    public Animator anim;
    public string escenas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CambioEscena());
        }
    }

    IEnumerator CambioEscena()
    {
        anim.SetTrigger("Jugar");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escenas);
    }

}
