using UnityEngine;
using System.Collections;

public class UpdateValues : MonoBehaviour {
    GameObject bossDamageField;
    GameObject partyDamageField;

    public string levelName;
	// Use this for initialization
	void Start () {
        bossDamageField = transform.FindChild("BossDamageLabel").gameObject;
        partyDamageField = transform.FindChild("PartyDamageLabel").gameObject;

       
    }
	
	// Update is called once per frame
	void Update () {
	    if(levelName == "L1")
        {
            bossDamageField.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("L1 - Boss Damage").ToString();
            partyDamageField.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("L1 - Party Damage").ToString();

        }
        else if (levelName == "L2")
        {
            bossDamageField.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("L2 - Boss Damage").ToString();
            partyDamageField.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("L2 - Party Damage").ToString();
        }
        else if (levelName == "L3")
        {
            bossDamageField.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("L3 - Boss Damage").ToString();
            partyDamageField.GetComponent<TextMesh>().text = PlayerPrefs.GetInt("L3 - Party Damage").ToString();
        }
	}
}
