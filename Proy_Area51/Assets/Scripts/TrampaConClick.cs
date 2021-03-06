﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaConClick : MonoBehaviour
{
    public int health = 10;
    public Movement player;
    public GameObject sealSprite;
    public GameObject notPlayer;
    public AudioSource roadingRock;

    public ParticleSystem piedra;
    public ParticleSystem piedra1;
    public ParticleSystem piedra2;
    ParticleSystem.EmissionModule piedraRate;
    ParticleSystem.EmissionModule piedraRate1;
    ParticleSystem.EmissionModule piedraRate2;
    float cont = 0.2f;
    private bool isActiveAndReady;
    private bool run = false;

    public CamMovement camera;
    public Animator oro;
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
        piedraRate = piedra.emission;
        piedraRate1 = piedra1.emission;
        piedraRate2 = piedra2.emission;
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
            camera.speed = 9;
            camera.impulseDirection = GetRandomDirection();
            //Aqui va la animacion
            //rockAnimator.SetTrigger("Play");
            GetValue();
            SetValue();
            print("Falta hacer click " + health + " vece(s)");
            if (health == 0)
            {
                print("Destroyed!");
                piedra.Stop();
                piedra1.Stop();
                piedra2.Stop();
                roadingRock.Stop();
                player.releaseFromCurse();

                DestroyThis();
            }
        }
        //Debug.Log("Mouse is over GameObject.");
    }

    private void TakeDamage()
    {
        health--;
    }
    private void DestroyThis()
    {
        oro.SetTrigger("Activar");
        Destroy(gameObject);
        Destroy(sealSprite);
    }

    public void Activate()
    {
        player.sealThis();
        isActiveAndReady = true;

    }

    Vector3 GetRandomDirection()
    {
        return ((new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f),0)).normalized);
    }

    public void GetValue()
    {
        Debug.Log("The constant value is " + piedraRate.rateOverTime.constant);
    }
    public void SetValue()
    {
        piedra.Play();
        piedra1.Play();
        piedra2.Play();
        for (int i = 0; i < health; i++)
        {
            piedraRate.rateOverTime = cont/8;
            piedraRate1.rateOverTime = cont/8;
            piedraRate2.rateOverTime = cont/8;
            cont++;
        }
    }
   
}

