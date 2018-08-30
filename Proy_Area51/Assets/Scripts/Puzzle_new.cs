using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_new : MonoBehaviour {
    public GameObject[] puzzle;
    public float speed=0.1f;
    int i = 0;
    public bool aumenta = false;
    public GameObject PuzzleController;
    // Use this for initialization
    void Start () {
        puzzle[i].GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W))
        {
            puzzle[i].transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            puzzle[i].transform.Translate(Vector2.down * speed * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            puzzle[i].transform.Translate(Vector2.left * speed * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            puzzle[i].transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        AumentaContador();
    }


    void AumentaContador()
    {
        if (aumenta == true)
        {
            i++;
            aumenta = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other = PuzzleController.GetComponent<Collider2D>();
        if (aumenta == false && other.tag=="Meta")
        {
            puzzle[i].gameObject.transform.parent = PuzzleController.transform;
            aumenta = true;
        }
    }


    /*void SwapRed()
    {
            Vector3 temp = transform.position;
            transform.position = other[i].transform.position;
             other[i].transform.position = temp;
    }*/


}
