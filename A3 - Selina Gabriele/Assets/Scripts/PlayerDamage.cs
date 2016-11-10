using UnityEngine;
using System.Collections;

public class PlayerDamage : MonoBehaviour
{
    public int maxDamage;
    public int minDamage;
    private int damageDealt;
    public int totalDamage;
    GameObject player;
    BossHealth bossHealth;
    PlayerHealth playerHealth;

    // Use this for initialization

    void Awake()
    {
        player = gameObject;
        playerHealth = player.GetComponent<PlayerHealth>();
        totalDamage = 0;
    }

    void Start()
    {
        bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (playerHealth.currentHealth > 0)
        {
            DealDamage();
        }else
        {
            playerHealth.Done();
        }


    }

    private void DealDamage()
    {
        if (bossHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            damageDealt = Random.Range(minDamage, maxDamage);
            totalDamage += damageDealt;
            bossHealth.TakeDamage(damageDealt);
        }
    }


}
