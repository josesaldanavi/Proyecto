using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceDelSuelo : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    public Collider2D collider;
    public ParticleSystem system;
    public ParticleSystem burstSystem;
    //public Rigidbody2D rigidbody2D;
    public float summonVelocity;
    public float waitTime;
    private bool canUse = true;

    private Transform thisParent;

    private Vector2 startPointThis;
    public Animator animator;


    public float maxHeight = 2f;
    public float minHeight = -3.5f;
    // Use this for initialization
    void Start()
    {
        DisableThis();
        thisParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableThis()
    {
        spriterenderer.enabled = true;
        collider.enabled = true;
    }
    public void DisableThis()
    {
        StopEmitting();
        spriterenderer.enabled = false;
        collider.enabled = false;
    }

    public void SummonThis(Vector3 startPoint)
    {
        if (canUse)
        {
            canUse = false;
            thisParent.position = startPoint;
            EnableThis();
            startPointThis = startPoint;
            StartCoroutine(RiseFromEarth(startPoint));
            //animator.SetTrigger("Rise");

            StartEmitting();
            PlayBurst();
        }

    }
    IEnumerator WaitAndReturn()
    {
        StopEmitting();
        yield return new WaitForSeconds(waitTime);
        ParentParticleToThis();
        //PlayBurst();
        //animator.SetTrigger("Back");
        yield return StartCoroutine(BackToEarth(startPointThis));
        Debug.Log("Ahora a bajar");
        FinishThisAnimation();

    }

    public void FinishThisAnimation()
    {
        DisableThis();
        StopEmitting();
        UnParentParticle();
        ReactivatePower();
    }

    //public void ReturnToEarth(){
    //    StartCoroutine(BackToEarth());
    //}

    private void ReactivatePower()
    {
        canUse = true;
    }
    public void StartEmitting()
    {
        system.Play();

    }
    public void StopEmitting()
    {
        system.Stop();
    }
    public void PlayBurst()
    {
        burstSystem.Play();
    }

    private void ParentParticleToThis()
    {
        system.transform.SetParent(this.transform);
        system.transform.localPosition = new Vector3(0, 2.5f, 0);
    }
    private void UnParentParticle()
    {
        system.transform.SetParent(this.transform.parent);
        system.transform.localPosition = Vector3.zero;
    }

    IEnumerator RiseFromEarth(Vector2 startPoint)
    {
        //transform.position = new Vector2(rigidbody2D.velocity.x,summonVelocity);

        Vector3 goal = new Vector3(0, maxHeight, 0);
        while (transform.localPosition != goal)
        {
            //transform.Translate(Vector3.up*Time.deltaTime);
            if (Input.GetKeyUp(KeyCode.W))
            {
                StartCoroutine(WaitAndReturn());
                yield break;
            }

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, goal, Time.deltaTime * summonVelocity);
            //Debug.Log(goal);

            //Debug.Log("transform"+transform.position);
            yield return null;
        }
        StartCoroutine(WaitAndReturn());
        //Debug.Log("fin!");
        //rigidbody2D.MovePosition(new Vector2(startPoint) + Vector2.up*3);
        //yield return new WaitForSeconds(waitTime);
    }

    IEnumerator BackToEarth(Vector2 startPoint)
    {
        //transform.position = new Vector2(rigidbody2D.velocity.x,summonVelocity);

        Vector3 goal = new Vector3(0, minHeight, 0);
        Debug.Log("goal(backtoEarth)= " + goal);
        while (transform.localPosition != goal)
        {
            //transform.Translate(Vector3.up*Time.deltaTime);


            transform.localPosition = Vector3.MoveTowards(transform.localPosition, goal, Time.deltaTime * summonVelocity);
            //Debug.Log(goal);

            //Debug.Log("transform"+transform.position);
            yield return null;
        }
        //Debug.Log("fin!");
        //rigidbody2D.MovePosition(new Vector2(startPoint) + Vector2.up*3);
        //yield return new WaitForSeconds(waitTime);
    }
}