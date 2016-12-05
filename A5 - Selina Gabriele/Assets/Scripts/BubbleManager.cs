using UnityEngine;
using System.Collections;

public class BubbleManager : MonoBehaviour
{
    public GameObject SpawnParent;
    public GameObject Bubble;
    public GameObject BackButton;
    public GameObject BubbleCounter;
    public float _spawnTime = 3f;
    private Transform[] SpawnPoints;
    private GameObject _currentBubble;
    private int _spawnIndex;
    public int _bubblesLost = 0;
    public int _bubblesHit = 0;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", _spawnTime, _spawnTime);
        SpawnPoints = SpawnParent.GetComponentsInChildren<Transform>();
        int counter = 0;
        foreach (var spawn in SpawnPoints)
        {
            Debug.Log("s" + counter + ": (" + spawn.transform.position.x + ", " + spawn.transform.position.x + ", " + spawn.transform.position.z + ")");
            counter++;
        }
    }

    // Update is called once per frame
    void Spawn()
    {
        _spawnIndex = Random.Range(1, SpawnPoints.Length - 1);

        _currentBubble = (GameObject)Instantiate(Bubble, SpawnPoints[_spawnIndex].position, SpawnPoints[_spawnIndex].rotation);
        _currentBubble.SetActive(true);

    }
    void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))

            {
                _bubblesHit++;
                Destroy(hit.transform.gameObject);
                Debug.Log(hit.transform.gameObject.transform.position.x + "," + hit.transform.gameObject.transform.position.y );

                BubbleCounter.GetComponent<TextMesh>().text = _bubblesHit.ToString();
            }
        }
        if (_bubblesLost >= 10)
        {
            Time.timeScale = 0;
            BackButton.SetActive(true);
        }
    }


}
