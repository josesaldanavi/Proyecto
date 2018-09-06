using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_nivel : MonoBehaviour {
    public Canvas canvas_fin;
    public Text txt_coin;
    public Text qOro;
    int puntosTotal;
	// Use this for initialization
	void Start () {
        canvas_fin.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        qOro.text = UIManager.coinCounter.ToString();
        puntosTotal = UIManager.coinCounter * 200;
        txt_coin.text = puntosTotal.ToString();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entro");
            canvas_fin.enabled = true;
        }
    }
}
