using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoAreaV2 : MonoBehaviour {
    public MovementSaltoV2 movement;

	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D other)
	{
        if(other.CompareTag("Player")){
            movement.OnTriggerEnterCall();
            Destroy(gameObject);
        }
	}
}
