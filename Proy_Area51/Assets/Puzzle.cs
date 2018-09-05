using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour {

	public Piece[] pieces;
	private Transform slotContainer;
    public Text winText;
	// Use this for initialization


	void Start () {
		slotContainer = transform.Find("SlotContainer");
        winText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckCompletion () {
		foreach (Transform slot in slotContainer) {
			if (slot.childCount == 0 || slot.GetSiblingIndex() != slot.GetChild(0).GetComponent<Piece>().id){
                
				return;
			}
		}
		//Call what you want on puzzle complete here
        winText.enabled = true;
		Debug.Log("YOU WIN!");
	}
}
