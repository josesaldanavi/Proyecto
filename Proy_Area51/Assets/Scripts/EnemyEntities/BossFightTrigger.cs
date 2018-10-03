using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightTrigger : MonoBehaviour {
    public MaskBossSummoner maskBossSummoner;
    private float normalCameraSize;
    public float bossCameraSize;
    private Camera thisCamera;
    public Collider2D collider;

	// Use this for initialization
	void Start () {
        thisCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            maskBossSummoner.StartFight();
            normalCameraSize = thisCamera.orthographicSize;
            collider.enabled = false;
            StartCoroutine(resizeCameraSize(bossCameraSize));
        }
    }
    IEnumerator resizeCameraSize(float newSize){
        while(newSize!=normalCameraSize){
            thisCamera.orthographicSize = Mathf.MoveTowards(thisCamera.orthographicSize, newSize, Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }


}
