using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskBossSummoner : MonoBehaviour {
    public MaskBoss redMaskBoss;
    public MaskBoss blueMaskBoss;
    public bool isOneDown = false;
    public GameObject monsterPrefab;
    public List<MovementSaltoV2> worms= new List<MovementSaltoV2>();
    public int numberOfMonstersPerWave;
    public int maxNumberOfMonster;

    public float timeBetweenSummon=6f;

    public float Ratio{ get { return 100/(redMaskBoss.hp + blueMaskBoss.hp+1); }}

	// Use this for initialization
	void Start () {
        blueMaskBoss.GoDown();
        StartCoroutine(SummonWormsRoutine(timeBetweenSummon));
        //redMaskBoss.GoUpAgain();
	}
	
	// Update is called once per frame
	void Update () {
        if (redMaskBoss.hp == 0 && blueMaskBoss.hp == 0)
            Destroy(gameObject);
	}

    public void CallitsDown(bool isLeftDown){
        if (isLeftDown)
           
            redMaskBoss.GoDown();
        else
           
            blueMaskBoss.GoDown();
    }
    IEnumerator SummonWormsRoutine(float timeBetween){
        while(true){
            yield return new WaitForSeconds(timeBetween);
            waveSummon(Mathf.Clamp(maxNumberOfMonster-worms.Count,0,numberOfMonstersPerWave));
        }
    }
    private void waveSummon(int quantity){
        for (int i = 0;i < quantity;i++){
            GameObject newWorm = Instantiate(monsterPrefab);
            newWorm.transform.SetParent(transform);
            newWorm.transform.localPosition = Vector3.zero+Vector3.right*i*0.01f;
            worms.Add(newWorm.GetComponent<MovementSaltoV2>());
        }

    }

    public void BuffMonstersAttack(){
        for (int i = 0; i < worms.Count;i++){
            worms[i].AttackBuff();
        }
    }
    public void BuffMonstersSpeed()
    {
        for (int i = 0; i < worms.Count; i++)
        {
            worms[i].SpeedBuff();
        }
    }
}
