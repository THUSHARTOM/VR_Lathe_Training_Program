using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;
    bool convStarted = false;

    float distance;
    float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entered influence area");
            convStarted = true;
            StartConversation();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Left influence area");
            convStarted = false;
            EndDialogue();
        }
    }

    //void OnMouseOver()
    void Update()
    {
        //distance = Vector3.Distance(player.transform.position, this.transform.position);
        //Debug.Log(distance);

        if (convStarted)
        {
            Debug.Log("Conv Started");
            DialogueControl();
        }
        //if (distance <=3.5f)
        //{
        //    Debug.Log("Inside Influence area");
        //    //trigger dialogue
        //    if (Input.GetKeyDown(KeyCode.E) && isTalking==false)
        //    {
        //        StartConversation();
        //    }
        //    else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
        //    {
        //        EndDialogue();
        //    }
        //}
    }
    void DialogueControl()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Debug.Log("Scroll Functions");
            curResponseTracker++;
            if (curResponseTracker >= npc.playerDialogue.Length - 1)
            {
                Debug.Log("Response tracker updated");
                curResponseTracker = npc.playerDialogue.Length - 1;
            }
        }

        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            curResponseTracker--;
            if (curResponseTracker < 0)
            {
                curResponseTracker = 0;
            }
        }

        if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
        {
            playerResponse.text = npc.playerDialogue[0];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Enter pressed");
                npcDialogueBox.text = npc.dialogue[1];
            }
        }
        else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
        {
            Debug.Log("Entered second Dialogue");
            playerResponse.text = npc.playerDialogue[1];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Dialog 1");
                npcDialogueBox.text = npc.dialogue[2];
            }
        }
        else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
        {
            playerResponse.text = npc.playerDialogue[2];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Dialog 2");
                npcDialogueBox.text = npc.dialogue[3];
            }
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
