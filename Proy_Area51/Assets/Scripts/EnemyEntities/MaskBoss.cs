using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBoss : Enemy {
    public Transform startTransform;

    private Vector3 startPosition;
    private Collider2D collider2D;
    private SpriteRenderer spriteRenderer;

    private bool canMove=true;
    public MaskBossSummoner summoner;
    public int maxHP;
    public Transform downTransform;
    private Vector3 downPosition;
    public Vector3 currentTarget;

    private bool canTakeDanage=false;

    public bool isLeft;
	// Use this for initialization
	protected override void Start () {
        base.Start();
        startPosition = startTransform.position;
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTarget = startTransform.position;
	}
	private void Update()
	{
        if(transform.position!=startPosition&&canMove)
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, Time.deltaTime);
	}
    public override void StabThis(Transform pua)
    {
        TakeDamage();
        canMove = false;
        transform.SetParent(pua);
    }
    public override void UnstabThis()
    {
        canMove = true;
        transform.SetParent(startParent);


    }
	protected override void DestroyThis()
	{
        collider2D.enabled = false;
        spriteRenderer.enabled = false;
	}
    public override void TakeDamage(int damage = 1)
    {
        base.TakeDamage();
        if( ((maxHP-hp)&(maxHP-hp-1))==0){
            Debug.Log("Vida restante es multiplo de 2");
            GoUpAgain();
        }
    }

    public void GoUpAgain(){
        canTakeDanage = false;
        currentTarget = startPosition;
        summoner.CallitsDown(isLeft);
    }
    public void GoDown(){
        canTakeDanage = true;
        currentTarget = downPosition;
    }
}
