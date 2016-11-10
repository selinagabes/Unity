using UnityEngine;
using System.Collections;
using System.Linq;

public class BossDamage : MonoBehaviour
{
    private int maxDamageToPlayer = 20;
    private int minDamageToPlayer = 5;   
    private int maxDamageToTank = 55;
    private int minDamageToTank = 45;
    private float previousDamage = 0;
    public int totalDamage = 0;
    public string playerName;

    private GameObject[] player;
    private GameObject tank;
    private PlayerHealth tankHealth;
    private BossHealth bossHealth;
    private PlayerHealth[] playerHealth = new PlayerHealth[4];
    private GameObject death; 
    // Use this for initialization

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
       
        tank = GameObject.FindGameObjectWithTag("Tank");
        for(int i = 0; i < player.Length; i++)
            playerHealth[i] = player[i].GetComponent<PlayerHealth>();
        tankHealth = tank.GetComponent<PlayerHealth>();
        bossHealth = GetComponent<BossHealth>();
        death = GameObject.FindGameObjectWithTag("GameOver");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO Seperate each with diff tag.. 
        if (bossHealth.currentHealth > 0)
        {
            DealDamage();
        }else
        {
            death.GetComponentInChildren<Death>(true).GameOver(playerName, bossHealth.totalDamageTaken, totalDamage);
            //death.GetComponentInChildren<Death>(true).playerName = playerName;
            //death.GetComponentInChildren<Death>(true).bossDamage = totalDamage;
            //death.GetComponentInChildren<Death>(true).partyDamage = bossHealth.totalDamageTaken;
            //death.GetComponentInChildren<Death>(true).isDead = true;
            //death.GetComponent<Death>().GameOver(playerName, bossHealth.totalDamageTaken, totalDamage);
        }
    }

    private void DealDamage()
    {
        float totalPlayerDamage = 0f;
        if (tankHealth.currentHealth > 0 && bossHealth.currentHealth > 0)
        {
            int ranTankRange = Random.Range(minDamageToTank, maxDamageToTank);
            int tankDamage = ranTankRange;
            if (playerName == "Boss3")
            {
                tankDamage += Mathf.RoundToInt(totalDamage / 100f);
            }
            tankHealth.TakeDamage(tankDamage);
       
            totalDamage += tankDamage;
            //Debug.Log(totalPlayerDamage);
            totalPlayerDamage += tankDamage; 
        }
       // previousDamage = 0;
        
        foreach (var p in playerHealth)
        {
            if (p.currentHealth > 0 && bossHealth.currentHealth > 0)
            {
                int ranRange = Random.Range(minDamageToPlayer, maxDamageToPlayer);
                totalDamage += ranRange;
                
                //Debug.Log(p.playerName + ": " + p.currentHealth + " damage: " + ranRange.ToString());
                p.TakeDamage(ranRange);
                totalPlayerDamage += ranRange;
            }

        }
        previousDamage += totalPlayerDamage;

    }

}
