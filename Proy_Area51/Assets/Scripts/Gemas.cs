using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemas : MonoBehaviour {
    public bool agarro;
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
                UIManager.gemaCounter ++ ;
                Destroy(gameObject);
                
            }
            Debug.Log(UIManager.gemaCounter);
        }
    }
}
