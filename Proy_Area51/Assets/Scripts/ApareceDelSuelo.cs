using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceDelSuelo : MonoBehaviour {
    public SpriteRenderer spriterenderer;
    public Collider2D collider;
    //public Rigidbody2D rigidbody2D;
    public float summonVelocity;
    public float waitTime;
    private bool canUse = true;

    private Transform thisParent;

    public Animator animator;
	// Use this for initialization
	void Start () {
        DisableThis();
        thisParent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableThis(){
        spriterenderer.enabled = true;
        collider.enabled = true;
    }
    public void DisableThis()
    {
        spriterenderer.enabled = false;
        collider.enabled = false;
    }

    public void SummonThis(Vector3 startPoint){
        if(canUse){
            canUse = false;
            thisParent.position = startPoint;
            EnableThis();
            animator.SetTrigger("Rise");
        }

    }
    IEnumerator BackToEarth(){
        yield return new WaitForSeconds(waitTime);
        animator.SetTrigger("Back");
    }

    public void FinishThisAnimation(){
        DisableThis();
        ReactivatePower();
    }

    public void ReturnToEarth(){
        StartCoroutine(BackToEarth());
    }

    private void ReactivatePower(){
        canUse = true;
    }

    /*IEnumerator RiseFromEarth(Vector2 startPoint){
        transform.position = new Vector2(rigidbody2D.velocity.x,summonVelocity);
        Vector3 goal = new Vector3(startPoint.x, startPoint.y + 5, 0);
        while(transform.position!=goal){
            transform.position = Vector3.MoveTowards()
            yield return null;
        }
        rigidbody2D.MovePosition(new Vector2(startPoint) + Vector2.up*3);
        yield return new WaitForSeconds(waitTime);
    }*/
}
