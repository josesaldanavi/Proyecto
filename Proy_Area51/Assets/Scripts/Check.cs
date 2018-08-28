using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour {

    private Movement player;
    private Rigidbody2D rb2d;

    void Start()
    {
        player = GetComponentInParent<Movement>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.tag == "platform")
        {
            player.transform.parent = col.transform;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            player.transform.parent = null;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "platform")
        {
            player.transform.parent = null;
        }
    }
}