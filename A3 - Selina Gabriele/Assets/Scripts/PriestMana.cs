using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PriestMana : MonoBehaviour
{

    public int startMana;
    public int currentMana;
    private List<GameObject> players;
    private GameObject[] player;
    private GameObject tank;
    private PlayerHealth tankHealth;
    private PlayerHealth[] playerHealth = new PlayerHealth[5];
    void Start()
    {
        currentMana = startMana;
        GameObject[] playerA = GameObject.FindGameObjectsWithTag("Player");
        players = new List<GameObject>();
        foreach (var gameObj in playerA)
        {
            players.Add(gameObj);
        }
        players.Add(gameObject); //Adds itself twice
        player = new GameObject[players.Count];
        //Debug.Log(player.Length);
        player = players.ToArray();

        tank = GameObject.FindGameObjectWithTag("Tank");
        for (int i = 0; i < player.Length; i++)
            playerHealth[i] = player[i].GetComponent<PlayerHealth>();
        tankHealth = tank.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (currentMana > 0 )
        {
            CastHeal(true);
            currentMana += 2;
            if (tankHealth.currentHealth < 1500 && gameObject.name == "Priest1")//named priest1 in level 2
            {
                CastHeal(false);
            }
        }

    }

    private void CastHeal(bool manaCost)
    {
       
        if (!playerHealth.Any(x => x.currentHealth < 0))
        {
            int randomSelect = Random.Range(0, player.Length - 1);

            playerHealth[randomSelect].Heal(15);        //selects randomly and heals
            if (manaCost)
                currentMana -= 5;
        }
        if (tankHealth.currentHealth > 0)
        {
            tankHealth.Heal(20);
            if (manaCost)
                currentMana -= 8;
        }
    }
}
