using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startHealth;
    public int currentHealth;
    public string playerName;
    private BossDamage bossDamage;
    private BossHealth bossHealth;
    private GameObject death; 

    // Use this for initialization

    void Awake()
    {
        currentHealth = startHealth;
      

        //Debug.Log(playerName + " Health: " + currentHealth + " Init");
    }
    void Start()
    {
        bossDamage = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossDamage>();
        bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();

        death = GameObject.FindGameObjectWithTag("GameOver");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(playerName + " Health: " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0)
        {
            Done();
        }
        else
        {
            currentHealth -= amount;
        }
    }

    public void Heal(int amount)
    {
        if (currentHealth >= 0)
        {
            currentHealth += amount;
        }

    }


    //TODO:: Make a script that enables the back button on Death()
    public void Done()
    {

        //death.GetComponentInChildren<Death>(true).playerName = bossDamage.playerName;
        //death.GetComponentInChildren<Death>(true).bossDamage = bossDamage.totalDamage;
        //death.GetComponentInChildren<Death>(true).partyDamage = bossHealth.totalDamageTaken;
        //death.GetComponentInChildren<Death>(true).isDead = true;
        death.GetComponentInChildren<Death>(true).GameOver(bossDamage.playerName, bossHealth.totalDamageTaken, bossDamage.totalDamage);


    }

}
