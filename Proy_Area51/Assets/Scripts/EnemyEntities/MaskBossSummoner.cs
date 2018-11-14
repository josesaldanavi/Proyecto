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
    public Transform wormParent;

    public Animator animator;

    public float Ratio{ get { return 100/(redMaskBoss.hp + blueMaskBoss.hp+1); }}

    public Final_nivel final_level;

	// Use this for initialization
	void Start () {
        //StartFight();
        //redMaskBoss.GoUpAgain();
	}
	
    	// Update is called once per frame
	void Update () {
        if (redMaskBoss.hp == 0 && blueMaskBoss.hp == 0)
            FinishLevel();
	}
    public void StartFight()
    {
        blueMaskBoss.GoDown();
        StartCoroutine(SummonWormsRoutine(timeBetweenSummon));
    }


    public void CallitsDown(bool isLeftDown){
        if (isLeftDown)
            //animator.SetTrigger("Gusanos");
            redMaskBoss.GoDown();
        else
           
            blueMaskBoss.GoDown();
    }
    IEnumerator SummonWormsRoutine(float timeBetween){
        while(true){
            yield return new WaitForSeconds(timeBetween);
            ClearMissingWorms();
            if(maxNumberOfMonster!=worms.Count)
            waveSummon(Mathf.Clamp(maxNumberOfMonster-worms.Count,0,numberOfMonstersPerWave));
        }
    }
    private void waveSummon(int quantity){
        animator.SetTrigger("Gusanos");
        for (int i = 0;i < quantity;i++){
            Transform newWormObject = Instantiate(monsterPrefab).transform;
            Transform newWorm = newWormObject.GetChild(0);
            newWormObject.SetParent(wormParent);
            newWormObject.localPosition = Vector3.zero + Vector3.right * i * 0.01f;
            
            worms.Add(newWorm.GetComponent<MovementSaltoV2>());
        }

    }

    public void BuffMonstersAttack(){
        Debug.Log("Buff attack");
        animator.SetTrigger("Daño1");
        for (int i = 0; i < worms.Count;i++){
            if(worms[i]!=null)
            worms[i].AttackBuff(2f);
        }
    }
    public void BuffMonstersSpeed()
    {
        Debug.Log("Buff speed");
        animator.SetTrigger("Daño2");
        for (int i = 0; i < worms.Count; i++)
        {
            if (worms[i] != null)
            worms[i].SpeedBuff(2f);
        }
    }

    void ClearMissingWorms(){
        for (int i = 0; i < worms.Count; i++)
        {
            if(worms[i]==null){
                worms.RemoveAt(i);
            }
        }
    }
    void FinishLevel()
    {
        final_level.showFinalCanvas();
        Destroy(gameObject);
    }
}
