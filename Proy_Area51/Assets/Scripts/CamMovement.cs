using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    public Transform targetObject;
    public Color targetColor;
    public float distance = 1;
    public float maxDistanceDelta = 1;

    public float speed = 0;
    float deaccel = 45;
    public Vector3 impulseDirection;

    Vector3 notClampedPosition;

    public Vector2 verticalLimit = new Vector2(0, 30);
    public Vector2 horizontalLimit = new Vector2(0, 100);
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (speed != 0)
        {
            speed = Mathf.MoveTowards(speed, 0, deaccel * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetCamPos = targetObject.position;
        Vector3 currentCamPos = transform.position;
        targetCamPos.z = transform.position.z;
        float currentDistance = Vector3.Distance(currentCamPos, targetCamPos);

        notClampedPosition = transform.position + impulseDirection * speed * Time.deltaTime;



        //notClampedTransform.Translate(impulseDirection * speed * Time.deltaTime);

        notClampedPosition = Vector3.MoveTowards(notClampedPosition, targetCamPos, maxDistanceDelta * currentDistance * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(notClampedPosition.x, horizontalLimit.x, horizontalLimit.y), Mathf.Clamp(notClampedPosition.y, verticalLimit.x, verticalLimit.y), -10);
    }

    /*void OnDrawGizmos()
    {
        Gizmos.color = targetColor;
        Vector3 targetViewPos = (targetScript != null) ? targetObject.position + (targetScript.sightDirection.up * distance) : Vector3.zero;
        Gizmos.DrawWireSphere(targetViewPos, 0.5f);
        Gizmos.color = Color.red;
        Vector3 currentViewPos = new Vector3(transform.position.x, transform.position.y, 0);
        Gizmos.DrawWireSphere(currentViewPos, 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(currentViewPos, targetViewPos);
    }*/
}