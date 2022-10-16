using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject startDialogue = null;
    [SerializeField] private GameObject startUnhappyDialogue = null;
    [SerializeField] private GameObject talkSign = null;
    public bool happy = true;
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
                talkSign.SetActive(false);
                Debug.Log("F key pressed");
                Cursor.lockState = CursorLockMode.None;
                //MouseLook.   find a way to switch bool indialogue to off in mouselook script to stop looking around 
                if (happy == true)
                {
                    startDialogue.SetActive(true);
                }
                else if (happy == false)
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
        }
    }
    public void MakeUnhappy()
    {
        happy = false;
        Debug.Log("npc is unhappy now");
    }
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


}
