
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSFX : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource playSound;
    //Animator m_anim;
    //SplineController spline;


    //public void Start()
    //{
    //    var tom = GameObject.Find("NPC_tom");
    //    m_anim = tom.GetComponent<Animator>();
    //    spline = tom.GetComponent<SplineController>();
    //    m_anim.SetBool("isWalking", false);
    //    //splineStart = GameObject.Find("NPC_tom").GetComponent<Animator>();
    //}


    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Inside Influence area");
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Object recognised as player");
            playSound.Play();
            //m_anim.SetBool("isWalking", true);
            //Debug.Log("SHOULDWALK");
            //spline.MoveMode();
            //m_anim.SetTrigger("animStart");
        }
        
    }

}
