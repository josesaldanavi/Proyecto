﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaConClick : MonoBehaviour
{
    public int health = 10;
    public Movement player;
    public GameObject sealSprite;
    public GameObject notPlayer;

    private bool isActiveAndReady;

    public CamMovement camera;
    // Use this for initialization
    void Awake()
    {
        /*Debug.Log("Object con tag",GameObject.FindGameObjectWithTag("Player").name);
        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Movement>();*/
        notPlayer = GameObject.FindGameObjectWithTag("Player");

    }

    void Start()
    {
        //Por ahora va a activarse cuando comienza.
        //Cambiar logica si se desea utilizarlo diferente despues.
        Activate();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isActiveAndReady)
        {
            TakeDamage();
            camera.speed = 5;
            camera.impulseDirection = GetRandomDirection(360);
            camera.impulseDirection = Vector3.up;
            if (health == 0)
            {
                print("Destroyed!");
                player.releaseFromCurse();
                DestroyThis();
            }

            print("Falta hacer click " + health + " vece(s)");
        }
        //Debug.Log("Mouse is over GameObject.");
    }

    private void TakeDamage()
    {
        health--;
    }
    private void DestroyThis()
    {
        Destroy(gameObject);
        Destroy(sealSprite);
    }

    public void Activate()
    {
        player.sealThis();
        isActiveAndReady = true;

    }

    Vector3 GetRandomDirection(float maxAngle)
    {
        float randomAngle = Random.Range(0f, maxAngle);
        Quaternion quat = Quaternion.Euler(new Vector3(0, 0, randomAngle));
        return quat * Vector3.forward;
    }
}

