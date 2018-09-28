using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaHijoEolico : MonoBehaviour {
    public PoderEolico eolico;
	// Use this for initialization
    public void FinishEolico(){
        eolico.FinishThisAnimation();
    }
}
