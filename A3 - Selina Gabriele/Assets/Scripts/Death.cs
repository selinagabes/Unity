using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour
{
    public bool isDead;
    public string playerName = "";

    public int partyDamage;
    public int bossDamage; 
    //public GameObject button;
    void Awake() { gameObject.SetActive(false); isDead = false; }
    
    void Update()
    {
        if (isDead) {
            GameOver(playerName, partyDamage, bossDamage);
        }

    }

    public void IsDead()
    {
        isDead = true; 
    }
    public void GameOver(string playerName, int partyDamage, int bossDamage)
    {
        if (playerName == "Boss1")
        {
            if (PlayerPrefs.GetInt("L1 - Party Damage") < partyDamage)
                PlayerPrefs.SetInt("L1 - Party Damage", partyDamage);
            if (PlayerPrefs.GetInt("L1 - Boss Damage") < bossDamage)
                PlayerPrefs.SetInt("L1 - Boss Damage", bossDamage);
        }
        if (playerName == "Boss2")
        {
            if (PlayerPrefs.GetInt("L2 - Party Damage") < partyDamage)
                PlayerPrefs.SetInt("L2 - Party Damage", partyDamage);
            if (PlayerPrefs.GetInt("L2 - Boss Damage") < bossDamage)
                PlayerPrefs.SetInt("L2 - Boss Damage", bossDamage);
        }
        if (playerName == "Boss3")
        {
            if (PlayerPrefs.GetInt("L3 - Party Damage") < partyDamage)
                PlayerPrefs.SetInt("L3 - Party Damage", partyDamage);
            if (PlayerPrefs.GetInt("L3 - Boss Damage") < bossDamage)
                PlayerPrefs.SetInt("L3 - Boss Damage", bossDamage);
        }
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
