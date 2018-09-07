using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenScript : MonoBehaviour {
    public Image images;
    public Final_nivel nivel_f;

    public Sprite[] sprites;
    public int[] scoreGoal;

    int maxPoint;
	// Use this for initialization
	void Start () {
        //images = GameObject.Find("Image").GetComponent<Image>();
        images.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        maxPoint = nivel_f.puntosTotal;

        for(int i=0;i< sprites.Length; i++)
        {
            if (maxPoint >= scoreGoal[i])
            {
                //images.sprite = Resources.Load<Sprite>("Sprites/fondo_juego");
                images.sprite = sprites[i];
                Active();
                break;
            }
        }

        
	}

    void Active()
    {
        images.enabled = true;
    }
}
