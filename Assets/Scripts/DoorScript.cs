using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Animator openandclose;

    // Use this for initialization
    void Start()
    {
        openandclose = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        openandclose.SetTrigger("Opening");
    }

    void OnTriggerExit(Collider other)
    {
        openandclose.SetTrigger("Closing");
    }

    void pauseEvent()
    {
        openandclose.enabled = false;
    }
}
