using UnityEngine;
using System.Collections;

public class UpdateBossHealth : MonoBehaviour
{
    private BossHealth bossH;
    private BossDamage bossD;
    // Use this for initialization
    void Start()
    {
        bossH = gameObject.GetComponentInChildren<BossHealth>();
        bossD = gameObject.GetComponentInChildren<BossDamage>();
        GetComponent<TextMesh>().text = "Health: " +bossH.currentHealth.ToString();
        GetComponent<TextMesh>().text += "\nDamage: " + bossD.totalDamage.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<TextMesh>().text = "Health: " + bossH.currentHealth.ToString();
        GetComponent<TextMesh>().text += "\nDamage: " + bossD.totalDamage.ToString();
    }
}