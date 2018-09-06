using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenScript : MonoBehaviour {
    public Image images;
    public Final_nivel nivel_f;
    int maxPoint;
	// Use this for initialization
	void Start () {
        images = GameObject.Find("Image").GetComponent<Image>();
        images.enabled = false;
        nivel_f = GetComponent<Final_nivel>();
	}
	
	// Update is called once per frame
	void Update () {
        maxPoint = nivel_f.puntosTotal;
        if (maxPoint>=1400)
        {
            images.sprite = Resources.Load<Sprite>("Sprites/fondo_juego");
            Active();
        }
	}

    void Active()
    {
        images.enabled = true;
    }
}
