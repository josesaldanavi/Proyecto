using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private RigidbodyType2D startRigidBodyType;
    protected Transform startParent;
    public Rigidbody2D charRigidbody2D;
    public int hp=1;

	// Use this for initialization
	protected virtual void Start () {
        //Debug.Log(transform.name +" has rigidBody type of "+charRigidbody2D.bodyType.ToString());
        startRigidBodyType = charRigidbody2D.bodyType;
        startParent = transform.parent;
	}
	
    public virtual void StabThis(Transform pua)
    {
        TakeDamage();
        charRigidbody2D.bodyType = RigidbodyType2D.Static;
        transform.SetParent(pua);
    }

    public virtual void UnstabThis()
    {
        charRigidbody2D.bodyType = startRigidBodyType;
        transform.SetParent(startParent);


    }
    public virtual void TakeDamage(int damage =1)
    {
        hp -= damage;
        if (hp <= 0) DestroyThis();
    }

    protected virtual void DestroyThis()
    {
        Destroy(gameObject);
    }

}
