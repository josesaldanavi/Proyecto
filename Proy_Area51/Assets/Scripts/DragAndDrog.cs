using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrog : MonoBehaviour {
    private bool selected;
    public GameObject slotGO;
    public int i; 
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (selected == true)
        {
            Vector2 cursorPosit = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(cursorPosit.x, cursorPosit.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            selected = false;
        }
	}
   
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selected = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name=="slot"+i)
        {
            Vector3 trans = Vector3.zero;
            slotGO.transform.position =  trans;
            gameObject.transform.parent = slotGO.transform;
        }
    }

}
