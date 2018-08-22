﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Image hpBar;
    public Movement playerScript;
    public Gradient barColors;
    public int coinCounter;
    public Text coinText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playerScript != null && hpBar.fillAmount != playerScript.normalizedHP)
        {
            float delta = Mathf.Abs(hpBar.fillAmount - playerScript.normalizedHP);
            if (delta < 0.2f) { delta = 0.2f; }
            hpBar.fillAmount = Mathf.MoveTowards(hpBar.fillAmount, playerScript.normalizedHP, 2f * delta * Time.deltaTime);
            hpBar.color = barColors.Evaluate(hpBar.fillAmount);
            Debug.Log(playerScript.normalizedHP);

        }
        coinText.text = "Coins:" + coinCounter;
	}
}
