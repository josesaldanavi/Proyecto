using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaConClick : MonoBehaviour {
    public int health = 10;
    private Movement player;
    public GameObject sealSprite;

    private bool isActiveAndReady;
	// Use this for initialization
    void Awake()
    {
        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Movement>();
    }

	void Start () {
        //Por ahora va a activarse cuando comienza.
        //Cambiar logica si se desea utilizarlo diferente despues.
        Activate();

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)&&isActiveAndReady) {
            TakeDamage();
            if (health == 0){
                print("Destroyed!");
                player.releaseFromCurse();
                DestroyThis();
            }

            print("Falta hacer click "+health+" vece(s)");
        }
        //Debug.Log("Mouse is over GameObject.");
    }

    private void TakeDamage()
    {
        health--;
    }
    private void DestroyThis() {
        Destroy(gameObject);
        Destroy(sealSprite);
    }
    
    public void Activate()
    {
        player.sealThis();
        isActiveAndReady = true;

    }
}
