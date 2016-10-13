using UnityEngine;
using System.Collections;

public class MoveSphere : MonoBehaviour
{
    public float _speed;
    private Rigidbody _RB;
    private Vector3 startPosition;
    public float _jumpHeight;
    private bool isSafe;

    // Use this for initialization
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
        startPosition = transform.position;
        isSafe = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _RB.AddForce(move * _speed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _RB.AddForce(new Vector3(0, _jumpHeight, 0), ForceMode.Impulse);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.gameObject.CompareTag("Safe"))
        {
            isSafe = true;
        }
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.SetActive(false);
        }
      
        if (other.gameObject.CompareTag("Fin"))
        {
            Debug.Log(other.GetComponent<Renderer>().material.color);
            other.GetComponent<Renderer>().material.color = new Color(0, 0.686f, 0.01f, 0.647f);
            Debug.Log(other.GetComponent<Renderer>().material.color);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Safe"))
        {
            isSafe = false;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Safe"))
        {
            isSafe = true;
        }
        if (other.gameObject.CompareTag("Death"))
        {
            if (!isSafe)
                transform.position = startPosition;
        }
    }
}
