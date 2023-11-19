using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InitiateRot : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    //private bool _shouldRotate = false;
    private bool _isPressed = false;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;


    public UnityEvent onPressed, onReleased;
    // Update is called once per frame

    public void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    public void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 0.5)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    
        //changeRotate();
        //if (_shouldRotate)
        //{
        //    _rotation = Vector3.forward;

        //    transform.Rotate(_rotation * Time.deltaTime * _speed);
        //}
        
    }

    //public void changeRotate()
    //{
    //    _shouldRotate = !_shouldRotate;
    //}
    
    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }

}
