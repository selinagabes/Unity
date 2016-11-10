using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {
    public int startHealth;
    public int currentHealth;
    public int totalDamageTaken = 0;
    public string playerName;
    private BossDamage bossDamage;
    private GameObject death; 
	// Use this for initialization

    void Awake()
    {
        currentHealth = startHealth;
        
    }
	void Start()
    {
        bossDamage = gameObject.GetComponent<BossDamage>();
        death = GameObject.FindGameObjectWithTag("GameOver");
    }
	// Update is called once per frame
	void FixedUpdate () {
        Debug.Log("Boss Health: " + currentHealth);
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
            totalDamageTaken += amount; 
        }
    }


    //TODO:: Make a script that enables the back button on Death()
    public void Done()
    {

        death.GetComponentInChildren<Death>(true).GameOver(playerName, totalDamageTaken, bossDamage.totalDamage);
        
    }
 
}
