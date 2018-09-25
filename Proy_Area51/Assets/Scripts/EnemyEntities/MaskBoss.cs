using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBoss : Enemy {
    public Transform startTransform;
    private Vector3 startPosition;

    private bool canMove=true;
	// Use this for initialization
	protected override void Start () {
        base.Start();
        startPosition = startTransform.position;
	}
	private void Update()
	{
        if(transform.position!=startPosition&&canMove)
        transform.position = Vector3.MoveTowards(transform.position, startPosition, Time.deltaTime);
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
}
