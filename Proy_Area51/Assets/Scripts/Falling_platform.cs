using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_platform : MonoBehaviour {

    private Rigidbody2D rbd2d;
    private PolygonCollider2D pol;
    public float time = 1f;
    public float respawnDelay = 1f;
    Vector3 start;

    // Use this for initialization
    void Start()
    {
        rbd2d = GetComponent<Rigidbody2D>();
        pol = GetComponent<PolygonCollider2D>();
        start = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Invoca un mentodo y lo hace despues de un cierto tiempo
            Invoke("Fall", time);
            Invoke("Respawn", time + respawnDelay);
        }
    }

    void Fall()
    {
        //hace que sea dinamico automaticamente
        rbd2d.isKinematic = false;
        pol.isTrigger = true;
    }
    void Respawn()
    {
        transform.position = start;
        rbd2d.isKinematic = true;
        pol.isTrigger = false;
        rbd2d.velocity = Vector3.zero;
    }
}