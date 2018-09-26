using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBossSummoner : MonoBehaviour {
    public MaskBoss redMaskBoss;
    public MaskBoss blueMaskBoss;



    public float Ratio{ get { return 100/(redMaskBoss.hp + blueMaskBoss.hp+1); }}

	// Use this for initialization
	void Start () {
        blueMaskBoss.GoDown();
        redMaskBoss.GoUpAgain();
	}
	
	// Update is called once per frame
	void Update () {
        if (redMaskBoss.hp == 0 && blueMaskBoss.hp == 0)
            Destroy(gameObject);
	}

    public void CallitsDown(bool isLeftDown){
        if (isLeftDown)
            blueMaskBoss.GoDown();
        else
            redMaskBoss.GoDown();
    }

}
