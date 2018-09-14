using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoderDePuas : MonoBehaviour {
    public SpriteRenderer spriterenderer;
    public Collider2D collider;

    public Collider2D stabCollider;
    //public ParticleSystem system;
    //public ParticleSystem burstSystem;
    //public Rigidbody2D rigidbody2D;
    public float summonVelocity;
    public float waitTime;
    private bool canUse = true;

    private Transform thisParent;

    public Animator animator;

    Transform monsterStabbed;

    bool isStabbingAMonster=false;
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
        //StopEmitting();
        spriterenderer.enabled = false;
        collider.enabled = false;
    }

    public void SummonThis(Vector3 startPoint){
        if(canUse){
            canUse = false;
            stabCollider.enabled = true;
            thisParent.position = startPoint;
            EnableThis();
            animator.SetTrigger("Rise");

            //StartEmitting();
            //PlayBurst();
        }

    }
    IEnumerator BackToEarth(){
        //StopEmitting();
        yield return new WaitForSeconds(waitTime);
        //ParentParticleToThis();
        //PlayBurst();
        animator.SetTrigger("Back");

    }

    public void FinishThisAnimation(){
        DisableThis();
        //StopEmitting();
        //UnParentParticle();
        ReactivatePower();
    }

    public void ReturnToEarth(){
        StartCoroutine(BackToEarth());
    }

    private void ReactivatePower(){
        canUse = true;
    }
    //public void StartEmitting()
    //{
    //    system.Play();

    //}
    //public void StopEmitting()
    //{
    //    system.Stop();
    //}
    //public void PlayBurst(){
    //	burstSystem.Play();
    //}

    //private void ParentParticleToThis()
    //{
    //    system.transform.SetParent(this.transform);
    //    system.transform.localPosition=new Vector3(0,2.5f,0);
    //}
    //private void UnParentParticle()
    //{
    //    system.transform.SetParent(this.transform.parent);
    //    system.transform.localPosition = Vector3.zero;
    //}

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

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Enemy")&&!isStabbingAMonster){
            StabMonster(col.transform);
        }
    }

    void StabMonster(Transform monster) {
        isStabbingAMonster = true;
        monster.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        monsterStabbed = monster;
        monster.SetParent(transform);
    }
    public void UnStabMonster() {
        stabCollider.enabled = false;
        isStabbingAMonster = false;
        if (monsterStabbed != null) {
            monsterStabbed.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            monsterStabbed.SetParent(null);
            monsterStabbed = null;
        }
        
    }


}
