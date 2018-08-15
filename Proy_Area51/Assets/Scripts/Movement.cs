using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D charRigidbody2D;
    public float characterSpeed;
    public float jumpSpeed = 10;
    public float health = 10;
    public float maxHealth = 10;

    public ApareceDelSuelo poderDelSuelo;



    public float rayDetectionDistance = 0.1f;
    public float normalizedHP { get { return health / maxHealth; } }
    Vector3 leftNode { get { return transform.position - new Vector3(0.5f, 1, 0); } }
    Vector3 rightNode { get { return transform.position + new Vector3(0.5f, -1, 0); } }
    bool isGrounded;
    SpriteRenderer spriteRenderer;


    public bool isSpriteFacingLeft = false;
    // Use this for initialization
    void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalSpeed = Input.GetAxis("Horizontal");
        if (horizontalSpeed != 0)
        {
            charRigidbody2D.velocity = new Vector2(horizontalSpeed * characterSpeed, charRigidbody2D.velocity.y);
        }
        if (horizontalSpeed < 0)
        {
            if (spriteRenderer.flipX == isSpriteFacingLeft) { spriteRenderer.flipX = !isSpriteFacingLeft; }
        }
        else if (horizontalSpeed > 0)
        {
            if (spriteRenderer.flipX == !isSpriteFacingLeft) { spriteRenderer.flipX = isSpriteFacingLeft; }
        }

    }

    private void FixedUpdate()
    {

        RaycastHit2D downLeft = Physics2D.Raycast(leftNode, Vector3.down, rayDetectionDistance);
        RaycastHit2D downRight = Physics2D.Raycast(rightNode, Vector3.down, rayDetectionDistance);

        if (isGrounded)
        {
            if (!downLeft && !downRight)
            {
                isGrounded = false;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                charRigidbody2D.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
                isGrounded = false;
            }else if(Input.GetKeyDown(KeyCode.W)){
                if(downLeft.collider&&downLeft.collider.CompareTag("Ground")){
                    SummonEarth(0); 
                }

            }
        }
        else
        {
            if ((downLeft || downRight)&& charRigidbody2D.velocity.y == 0)
            {
                isGrounded = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(leftNode, 0.2f);
        Gizmos.DrawSphere(rightNode, 0.2f);
        Gizmos.color = Color.white;
        Gizmos.DrawRay(leftNode, Vector3.down * rayDetectionDistance);
    }

    public void SummonEarth(float distance){
        Vector3 startPoint = new Vector3(transform.position.x+distance, transform.position.y, transform.position.z);
        poderDelSuelo.SummonThis(startPoint);
    }
}
