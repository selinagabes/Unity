using UnityEngine;
using System.Collections;

public class BubbleLife : MonoBehaviour {
    private float _startTime;
    public float _timeAlive;
    private float _bubblesLost=0;
    public GameObject BubbleManager;
    public GameObject BubbleCounter;
    // Use this for initialization
    void Awake () {
        _startTime = Time.realtimeSinceStartup;
        _timeAlive = Time.realtimeSinceStartup - _startTime;
        FloatAround();
     
    }
	
	// Update is called once per frame
	void Update () {
        
        _timeAlive = Time.realtimeSinceStartup - _startTime;
        if (_timeAlive >= 10f)
        {
            Destroy(gameObject);
            BubbleManager.GetComponent<BubbleManager>()._bubblesLost++;

        }else { FloatAround(); }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out hit))
            {
                BubbleManager.GetComponent<BubbleManager>()._bubblesHit++;
                Destroy(hit.collider.gameObject);
                Debug.Log(hit.transform.gameObject.transform.position.x + "," + hit.transform.gameObject.transform.position.y);

                BubbleCounter.GetComponent<TextMesh>().text = BubbleManager.GetComponent<BubbleManager>()._bubblesHit.ToString();
            }
        }
    }

    void FloatAround()
    {
        if(BubbleManager.GetComponent<BubbleManager>()._bubblesLost >= 10)
        {
            Destroy(gameObject);
        }
        float x0 = -transform.position.normalized.x;
        float y0 = -transform.position.normalized.y;
        GetComponent<Rigidbody>().AddForce(x0, y0, 0f, ForceMode.Force);
    }
}
