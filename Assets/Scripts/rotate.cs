using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationClampMin;
    [SerializeField] private float _rotationClampMax;

    public static int _shouldRotate = 0;

    // Update is called once per frame
    public void Update()
    {
        
        _rotation = Vector3.forward;

        transform.Rotate(_rotation * Time.deltaTime * _shouldRotate *_speed);
        
            // Clamping the rotation
            //Quaternion clampedRotation = ClampRotation(transform.rotation.eulerAngles);
            //transform.rotation = Quaternion.Euler(clampedRotation.eulerAngles);
        

    }

    

    private Quaternion ClampRotation(Vector3 eulerRotation)
    {
        eulerRotation.z = Mathf.Clamp(eulerRotation.z, _rotationClampMin, _rotationClampMax);
        return Quaternion.Euler(eulerRotation);
    }
}
