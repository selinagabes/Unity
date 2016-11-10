using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Slerper : MonoBehaviour
{
    private Vector3 _start;
    private Vector3 _end;
    private Vector3 _center;
    private Vector3 _startRel;														// Where's the "sunrise" object wrt the center we compute
    private Vector3 _endRel;                                                        // Where's the "sunset" object wrt the center we compute
    public Toggle _isAutomatic;
    public Scrollbar _scroller;
    public Vector3 _passesThrough = new Vector3(0, 1, 0);

    private float _lerpStartTime;
    public float _lerpTotalTime = 5f;
    public float _distanceToMove = 20f;
    public bool _isOnZAxis = false;
    public float _percentageTrip;

    void Start()
    {
        _lerpStartTime = Time.time;
        _start = transform.position;
        _end = transform.position + (Vector3.right * _distanceToMove);
        _center = (_start + _end) * 0.5f;
        _center -= _passesThrough;
        _startRel = _start - _center;
        _endRel = _end - _center;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_isAutomatic.isOn)
        {
            _percentageTrip = (Time.time - _lerpStartTime) * (_lerpTotalTime / _distanceToMove);
        }
        else
        {
            _percentageTrip = _scroller.value;
        }

        transform.position = Vector3.Slerp(_startRel, _endRel, _percentageTrip);

        if (gameObject.name != "Slerp0")
            transform.position += _center;
        //if (!_isOnZAxis)
        //    
        if (_isOnZAxis)
        {
            transform.position -= new Vector3(0, 0, (transform.position.z / 2f));
        }

        Debug.DrawLine(_center + new Vector3(0, 1, 1), transform.position + new Vector3(0, 0, 1), Color.red, 20f);
        if (Mathf.Abs(_percentageTrip) >= 1f)
        {

            Vector3 swap = _startRel;
            _startRel = _endRel;
            _endRel = swap;
            _lerpStartTime = Time.time;
        }
    }

    public void ResetEverything()
    {
        _lerpStartTime = Time.time;
        _start = new Vector3(-10, 0, 0);
        _end = new Vector3(10, 0, 0);   // transform.position + (Vector3.right * _distanceToMove);
        _center = (_start + _end) * 0.5f;
        _center -= _passesThrough;
        Debug.Log(_passesThrough);
        _startRel = _start - _center;
        _endRel = _end - _center;
    }
}
