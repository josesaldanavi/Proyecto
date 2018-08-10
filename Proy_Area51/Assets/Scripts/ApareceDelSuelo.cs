using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApareceDelSuelo : MonoBehaviour {
    public SpriteRenderer spriterenderer;
    public Collider2D collider;
    public Rigidbody2D rigidbody2D;
    public float summonVelocity;
    public float waitTime;
	// Use this for initialization
	void Start () {
        DisableThis();
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

    public void SummonThis(){
        
    }


    /*IEnumerator RiseFromEarth(Vector2 startPoint){
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,summonVelocity);
        while(transform.localPosition.y<startPoint+3){
            yield return null;
        }
        rigidbody2D.MovePosition(new Vector2(transform.parent.position) + Vector2.up*3);
        yield return new WaitForSeconds(waitTime);
    }*/
}
