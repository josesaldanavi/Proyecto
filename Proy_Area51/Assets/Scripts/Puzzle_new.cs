using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_new : MonoBehaviour {
    public GameObject[] other;
    //public bool check=false;
    int i = 0;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) && i<=5)
        {
            SwapRed();
            i++;
        }
        if (i == 4)
        {
            i = 0;
        }
	}
 

    void SwapRed()
    {
            Vector3 temp = transform.position;
            transform.position = other[i].transform.position;
             other[i].transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            
        }
    }
}
