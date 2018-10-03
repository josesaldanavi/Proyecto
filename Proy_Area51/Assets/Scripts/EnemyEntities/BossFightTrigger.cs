using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightTrigger : MonoBehaviour {
    public MaskBossSummoner maskBossSummoner;
    private float normalCameraSize;
    public float bossCameraSize;
    private Camera thisCamera;
    public Collider2D collider;
    private bool isBossActive = false;

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
            if(!isBossActive){
                maskBossSummoner.StartFight();
                normalCameraSize = thisCamera.orthographicSize;
                isBossActive = true;
            }

            //collider.enabled = false;
            StartCoroutine(resizeCameraSize(bossCameraSize, Camera.main));
        }
    }
    public static IEnumerator resizeCameraSize(float newSize, Camera camRef,GameObject reference=null){
        while(camRef.orthographicSize!=newSize){
            camRef.orthographicSize = Mathf.MoveTowards(camRef.orthographicSize, newSize, Time.deltaTime);
            yield return null;
        }
        if (reference) { Destroy(reference); }
    }


}
