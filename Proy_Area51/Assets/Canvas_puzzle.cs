using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_puzzle : MonoBehaviour {
	//public Canvas canvas_puz;
    public Canvas canvas_dialog;
    public DialogController dialog;
	// Use this for initialization
	void Start () {
		//canvas_puz.enabled=false;
        canvas_dialog.enabled = false;
        dialog.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag =="Player"){
            //canvas_puz.enabled=true;
            canvas_dialog.enabled = true;
            dialog.enabled = true;
            Movement.isPuzzleNotActive=true;
			 Destroy(gameObject);

		}
	}
}
