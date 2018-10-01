using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Rigidbody2D charRigidbody2D;
    public float characterSpeed;
    public float jumpSpeed = 10;
    public float health = 10;
    public float maxHealth = 10;
    public int lifes = 1;
    public Vector3 checkpoint;

    public GameObject personalSealImage;

    public static bool isPuzzleNotActive;

    private bool isSealed;

    public ApareceDelSuelo poderDelSuelo;
    public PoderDePuas poderDePuas;
    public PoderEolico poderEolico;

    public static bool activarPoder_Murralla=false;
    public static bool activarPoder_pua = true;
    public static bool activarPoder_Estruendo = false;
    public Animator animator2d;


    public float rayDetectionDistance = 0.1f;
    public float normalizedHP { get { return health / maxHealth; } }
    Vector3 leftNode { get { return transform.position - new Vector3(0.5f, 1, 0); } }
    Vector3 rightNode { get { return transform.position + new Vector3(0.5f, -1, 0); } }
    bool isGrounded;
    public SpriteRenderer spriteRenderer;


    public bool isSpriteFacingLeft = false;

    public GameOverScript gameOverObject;


    public bool isSummoning=false;
    private bool isDead = false;
    // Use this for initialization
    void Start()
    {
    	isPuzzleNotActive = false;
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isSealed && !isPuzzleNotActive&&!isSummoning)
            {
                float horizontalSpeed = Input.GetAxis("Horizontal");
                if (horizontalSpeed != 0)
                {
                    animator2d.SetInteger("Speed2", 1);

                }
                else
                {
                    animator2d.SetInteger("Speed2", 0);
                }
                if (horizontalSpeed < 0)
                {
                    if (spriteRenderer.flipX == isSpriteFacingLeft) { spriteRenderer.flipX = !isSpriteFacingLeft; }
                }
                else if (horizontalSpeed > 0)
                {
                    if (spriteRenderer.flipX == !isSpriteFacingLeft) { spriteRenderer.flipX = isSpriteFacingLeft; }
                }
                charRigidbody2D.velocity = new Vector2(horizontalSpeed * characterSpeed, charRigidbody2D.velocity.y);
            }
            else
            {
                
                charRigidbody2D.velocity = new Vector2(0f, charRigidbody2D.velocity.y);
                if (!isSummoning&&!isDead)
                animator2d.SetInteger("Speed2", 0);
            }
        
       
    }

    private void FixedUpdate()
    {

        if (!isSealed && !isPuzzleNotActive && !isSummoning)
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
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    if (downLeft.collider && downLeft.collider.CompareTag("Ground"))
                    {
                        if (activarPoder_Murralla)
                            SummonEarth(0);
                    }

                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    if (downLeft.collider && downLeft.collider.CompareTag("Ground"))
                    {
                        if (activarPoder_pua)
                            StartSummoning();


                    }
                }
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    if (downLeft.collider && downLeft.collider.CompareTag("Ground"))
                    {
                        if (activarPoder_Estruendo)
                            StartSummoningV2();


                    }
                }
            }
            else
            {
                if ((downLeft || downRight) && charRigidbody2D.velocity.y == 0)
                {
                    isGrounded = true;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        

        //health -= damage;

        //health=Mathf.Clamp(health, 0f, maxHealth);

        //if (health == 0 && !isPuzzleNotActive)
        //{
        //    personalSealImage.SetActive(true);
        //    isPuzzleNotActive = true;
        //}

        if (!isPuzzleNotActive)
        {
            health -= damage;

            health = Mathf.Clamp(health, 0f, maxHealth);
            if (health == 0)
            {
                transform.position = checkpoint;
                lifes--;

                if (lifes > 0)
                {
                    health = maxHealth;
                }       
                else
                {
                    personalSealImage.SetActive(true);
                    isPuzzleNotActive = true;
                    animator2d.SetTrigger("Muerte");
                    gameOverObject.playGameOver();
                    isDead = true;
                    //Destroy(player);
                    //SceneManager.LoadScene(0);
                }


            }
        }

        
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

    public void SummonSpike(float distance) {
        Vector3 startPoint = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        poderDePuas.SummonThis(startPoint);
    }

    public void SummonEolicPower(float distance)
    {
        Vector3 startPoint = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        poderEolico.SummonThis(startPoint,spriteRenderer.flipX);

        Debug.Log("Poder eolico");
    }


    public void releaseFromCurse()
    {

        animator2d.SetTrigger("Comienzo");
        isSealed = false;
    }

    public void sealThis()
    {
        isSealed = true;
    }
    /*public static void stopMovement(){
    	isPuzzleNotActive=true;
    	charRigidbody2D.velocity =Vector2.zero;
    }*/
    public void renderFrontOfEverything()
    {
        spriteRenderer.material.renderQueue = 4001;
    }

    private void StartSummoning() {
        isSummoning = true;
        animator2d.SetInteger("Speed2", 2);
    }
    private void StartSummoningV2()
        {
            isSummoning = true;
            animator2d.SetInteger("Speed2", 3);
        }



    public void summonSpikeNow() {
        
        SummonSpike((spriteRenderer.flipX) ? -1 : 1);
        isSummoning = false;
    }

    public void summonEolicPowerNow()
    {

        SummonEolicPower((spriteRenderer.flipX) ? -1 : 1);
        isSummoning = false;
    }

    private void OnBecameInvisible()
    {
        transform.position = checkpoint;
        TakeDamage(3);
        /*if (lifes > 0)
        {
            Tak
        }
        else
        {
            //Destroy(player);
            SceneManager.LoadScene(0);
        }*/
    }

}
