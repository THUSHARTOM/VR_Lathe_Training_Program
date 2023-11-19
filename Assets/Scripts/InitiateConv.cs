using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitiateConv : MonoBehaviour
{


    public NPC npc;

    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    private void Start()
    {
        // Deactivate or hide the board object
        dialogueUI.SetActive(false); // or use gameObject.SetActive(false) to hide the object
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if(Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Debug.Log("Sc");
                curResponseTracker++;
                if(curResponseTracker >=npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }

            else if(Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                curResponseTracker--;
                if(curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }
            StartConversation();

            if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
                else if(curResponseTracker ==1 && npc.playerDialogue.Length >=1)
                {
                    playerResponse.text = npc.playerDialogue[1];
                    if(Input.GetKeyDown(KeyCode.Return))
                    {
                        npcDialogueBox.text = npc.dialogue[2];  
                    }
                }
                else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
                {
                    playerResponse.text = npc.playerDialogue[2];
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        npcDialogueBox.text = npc.dialogue[3];
                    }
                }

            }
            //Debug.Log("pLAYER RECOGNIZED");
            //if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            //{
            //    Debug.Log("E PRESSED");
            //    StartConversation();
            //}
            //else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            //{
            //    EndDialogue();
            //}
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndDialogue();
        }
    }

    void StartConversation()
    {
        Debug.Log("Start Conversation");
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];

    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1);

    }
}