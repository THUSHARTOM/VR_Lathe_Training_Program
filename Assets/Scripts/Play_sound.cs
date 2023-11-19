using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_sound : MonoBehaviour
{

    public AudioSource playSound;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Inside Influence area");
        if (other.CompareTag("Player"))
        {
            Debug.Log("notworking!!!!!!!");
            playSound.Play();
            //Debug.Log("Board showed");
        }

        
    }

}
