using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject startDialogue = null;
    [SerializeField] private GameObject startUnhappyDialogue = null;
    [SerializeField] private GameObject talkSign = null;
    public float moodval = 80;
    public playerController playerController;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            talkSign.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerController.talking();
                talkSign.SetActive(false);
                Debug.Log("F key pressed");
                Cursor.lockState = CursorLockMode.None;
                playerController.isInteracting = true;
                //MouseLook.   find a way to switch bool indialogue to off in mouselook script to stop looking around 
                if (moodval >= 50)
                {
                    startDialogue.SetActive(true);
                }
                else if (moodval < 50)
                {
                    startUnhappyDialogue.SetActive(true);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            talkSign.SetActive(false);
            startDialogue.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            playerController.isInteracting = false;
        }
    }
    public void LowerMoodval()
    {
        moodval -= 40;
        Debug.Log("npc is LESS HAPPY now");
    }
    public void RiseMoodval()
    {
        moodval = 60;
        Debug.Log("npc is MORE HAPPY now");
    }
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


}
