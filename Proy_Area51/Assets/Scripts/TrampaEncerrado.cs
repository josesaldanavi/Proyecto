using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaEncerrado : MonoBehaviour {
    public int health=20;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if(Input.GetKeyDown(KeyCode.Tab)){
            TakeDamage();
        }*/
	}

    private void TakeDamage(){
        health--;
        if(health<=0){
            Break();
        }
    }

    private void Break(){
        //Momentaneo. Despues DestroyThis se va a llamar a fin de la animacion como evento
        //Y aqui solo se llama a la animacion
        DestroyThis();
    }

    private void DestroyThis(){
        Destroy(gameObject);
    }

    public void CallOnCollisionEnter2D()
	{
        
            TakeDamage();

	}
}
