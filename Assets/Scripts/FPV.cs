using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FPV : MonoBehaviour
{
    public float Speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;

    private GameObject playerRigidbody;

    private void Start()
    {

    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        // playerRigidbody.AddForce(movement * speed);

        transform.Translate(Vector3.forward * Time.deltaTime * Speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * Speed * horizontalInput);
    }
}