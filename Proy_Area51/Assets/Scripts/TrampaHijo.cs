using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaHijo : MonoBehaviour {

    public TrampaEncerrado trampa;

	public void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.CompareTag("Player"))
        {
            trampa.CallOnCollisionEnter2D();
        }
	}

}
