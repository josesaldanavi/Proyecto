
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSaltoV2 : Enemy
{

    public float characterSpeed;
    public float jumpSpeed = 10;
    public float distance = -1f;
    public int attack = 1;
    public float maxJumpHorizontal = 5f;

    public bool isAttacking = false;

    private Transform player;

    int actualTarget = 0;

    public Transform[] points;

    public float patrolSpeed = 1f;

    public SpriteRenderer renderer;
    private bool isGrounded = true;
    private bool hasBuff = false;


    Vector3 leftNode { get { return transform.position - new Vector3(0.5f, 1, 0); } }
    Vector3 rightNode { get { return transform.position + new Vector3(0.5f, -1, 0); } }
    public float rayDetectionDistance = 0.1f;

    public Animator anim2D;

    private float modifiedAttack;
    private float modifiedJumpSpeed;



    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        if (points.Length != 0)
        {
            Debug.Log("Lenght is : " + points.Length);
            anim2D.SetInteger("MoveState", 3);
        }
        modifiedAttack = attack ;
        modifiedJumpSpeed = jumpSpeed ;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Corregir despues

        if (!isAttacking)
        {
            if (points.Length != 0)
            {

                float distanceToPlayer = points[actualTarget].position.x - transform.position.x;
                renderer.flipX = distanceToPlayer > 0;

                if (Mathf.Abs(distanceToPlayer) < 0.1f)
                {
                    actualTarget += 1;
                    if (actualTarget == points.Length)
                    {
                        actualTarget = 0;
                    }
                }

                charRigidbody2D.velocity = new Vector2(Mathf.Sign(distanceToPlayer) * patrolSpeed, charRigidbody2D.velocity.y);

            }
        }
        else
        {
            float distanceToPlayer = player.position.x - transform.position.x;
            renderer.flipX = distanceToPlayer > 0;
            RaycastHit2D downLeft = Physics2D.Raycast(leftNode, Vector3.down, rayDetectionDistance);
            RaycastHit2D downRight = Physics2D.Raycast(rightNode, Vector3.down, rayDetectionDistance);
            isGrounded = !(!downLeft && !downRight);
            if (isGrounded)
            {
                anim2D.SetInteger("MoveState", 1);
            }
            else
            {
                anim2D.SetInteger("MoveState", 2);
            }
        }


    }


    public void OnTriggerEnterCall()
    {
        Jump(distance);
        isAttacking = true;
    }

    public void Jump(float jumpDistance)
    {
        Debug.Log("Jumping!");
        charRigidbody2D.AddForce(Vector2.up * jumpSpeed + Vector2.right * jumpDistance, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("Player"))
        {
            Movement movement = collisionObject.GetComponent<Movement>();
            if (movement)
            {
                movement.TakeDamage(attack);

            }
        }
        if (isAttacking && !Movement.isPuzzleNotActive)
        {
            JumpAttack();
        }
    }

    public void JumpAttack()
    {
        float distanceToPlayer = player.position.x - transform.position.x;
        //Debug.Log(distanceToPlayer / 2);
        if (charRigidbody2D.velocity.x < 0 && distanceToPlayer < 0)
        {
            charRigidbody2D.velocity = new Vector2(-0.01f, charRigidbody2D.velocity.y);
        }
        else if (charRigidbody2D.velocity.x > 0 && distanceToPlayer > 0)
        {
            charRigidbody2D.velocity = new Vector2(0.01f, charRigidbody2D.velocity.y);
        }
        Debug.Log("Distance: " + distanceToPlayer + ", Velocity(X):" + charRigidbody2D.velocity.x);
        Jump(Mathf.Clamp(distanceToPlayer / 2, -maxJumpHorizontal, maxJumpHorizontal));
    }

    public void ChangeBuff(float attackModifier, float jumpSpeedModifier){
        modifiedAttack = attack * attackModifier;
        modifiedJumpSpeed = jumpSpeed * jumpSpeedModifier;
        
    }
    public void SpeedBuff(float jumpSpeedModifier){
        //ChangeBuff(1f, 2f);
        modifiedJumpSpeed=jumpSpeed * jumpSpeedModifier;
        renderer.color = Color.blue;
        Debug.Log("Cambia a azul");
        //StartCoroutine(waitAndReturnToNormal());
    }
    public void AttackBuff(float attackModifier){
        //ChangeBuff(2f, 1f);
        modifiedAttack = attack * attackModifier;
        renderer.color = Color.red;
        //StartCoroutine(waitAndReturnToNormal());
    }
    public void BackToNormal(){
        ChangeBuff(2f, 1f);
    }



    IEnumerator waitAndReturnToNormal(){
        yield return new WaitForSeconds(5f);
        BackToNormal();
    }
}