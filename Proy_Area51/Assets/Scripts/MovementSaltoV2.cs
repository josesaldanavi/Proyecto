using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSaltoV2 : MonoBehaviour {
    public Rigidbody2D charRigidbody2D;
    public float characterSpeed;
    public float jumpSpeed=10;
    public float distance = -1f;
    public int attack = 1;
    public float maxJumpHorizontal = 5f;

    public bool isAttacking = false;

    public Transform player;

    int actualTarget = 0;

    public Transform[] points;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Corregir despues
        if (!isAttacking)
        {
            float distanceToPlayer = points[actualTarget].position.x - transform.position.x;

            if (Mathf.Abs(distanceToPlayer) < 0.1f)
            {
                actualTarget += 1;
                if (actualTarget == 1)
                {
                    actualTarget = 0;
                }
            }
            charRigidbody2D.velocity = new Vector2(Mathf.Sign(distanceToPlayer)*1f, charRigidbody2D.velocity.y);

        }

	}


    public void OnTriggerEnterCall()
	{
        Jump(distance);
        isAttacking = true;
	}

    public void Jump(float jumpDistance){
        Debug.Log("Jumping!");
        charRigidbody2D.AddForce(Vector2.up * jumpSpeed + Vector2.right * jumpDistance, ForceMode2D.Impulse);
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        GameObject collisionObject = collision.gameObject;
        if(collisionObject.CompareTag("Player")){
            Movement movement = collisionObject.GetComponent<Movement>();
            if(movement){
                movement.TakeDamage(attack);

            }
        }
        if(isAttacking&&!Movement.isPuzzleNotActive){
            JumpAttack();
        }
	}

    public void JumpAttack(){
        float distanceToPlayer = player.position.x-transform.position.x;
        //Debug.Log(distanceToPlayer / 2);
        if (charRigidbody2D.velocity.x < 0 && distanceToPlayer < 0)
        {
            charRigidbody2D.velocity = new Vector2(-0.01f, charRigidbody2D.velocity.y);
        }
        else if (charRigidbody2D.velocity.x > 0 && distanceToPlayer > 0)
        {
            charRigidbody2D.velocity = new Vector2(0.01f, charRigidbody2D.velocity.y);
        }
        Debug.Log("Distance: "+distanceToPlayer+", Velocity(X):"+ charRigidbody2D.velocity.x);
        Jump(Mathf.Clamp(distanceToPlayer / 2,-maxJumpHorizontal,maxJumpHorizontal));
    }
}
