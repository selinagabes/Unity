using UnityEngine;
using System.Collections;

public class UpdateHealth : MonoBehaviour {
    private PlayerHealth player;
	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInChildren<PlayerHealth>();
        GetComponent<TextMesh>().text = player.currentHealth.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<TextMesh>().text = "Health: " + player.currentHealth.ToString();

       // Debug.Log(gameObject.name);
        if(gameObject.name == "Priest" || gameObject.name == "Priest1")
        {
            var mana = gameObject.GetComponentInChildren<PriestMana>();
            GetComponent<TextMesh>().text += "\n Mana: " + mana.currentMana;
        }
        else
        {
            var damage = gameObject.GetComponentInChildren<PlayerDamage>();
            GetComponent<TextMesh>().text += "\n Damage: " + damage.totalDamage;
        }
    }
}
