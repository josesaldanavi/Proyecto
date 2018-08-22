using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    public bool agarro;
    public UIManager manager;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && agarro == false)
        {
            agarro = true; 
            if (agarro)
            {
                Destroy(gameObject);
                manager.coinCounter++;
            }
            Debug.Log(manager.coinCounter);
        }
    }
}
