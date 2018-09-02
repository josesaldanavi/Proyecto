using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa_script : MonoBehaviour {
    bool activado;
   public static Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
	}
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            activado = !activado;
            canvas.enabled = activado;
            Time.timeScale = (activado) ? 0 : 1f;
        }
	}
}
