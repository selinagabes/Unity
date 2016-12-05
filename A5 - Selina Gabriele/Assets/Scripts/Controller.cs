using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public GameObject bubble;
    public GameObject[] positions = new GameObject[8];


    public int bubbleCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        StartCoroutine(Wave());
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(hit.collider.gameObject);
                score++;
            }
        }
	}

    IEnumerator Wave()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < bubbleCount; ++i)        
            {
                int position = Random.Range(0, 8);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(bubble, positions[position].transform.position, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
