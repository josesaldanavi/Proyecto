using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gemas : MonoBehaviour {
    public bool agarro;
    public static int  gemaCounter;
    public Movement lifesUp;
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
                gemaCounter ++ ;
                Destroy(gameObject);
                if (gemaCounter % 10 == 0)
                {
                    lifesUp.lifes++;
                }
                
            }
            Debug.Log(gemaCounter);
        }
    }
}
