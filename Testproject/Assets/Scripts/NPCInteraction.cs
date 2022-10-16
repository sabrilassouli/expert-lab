using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject startDialogue = null;
    [SerializeField] private GameObject startUnhappyDialogue = null;
    [SerializeField] private GameObject talkSign = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed");
            Cursor.lockState = CursorLockMode.None;
            //MouseLook.   find a way to switch bool indialogue to off in mouselook script to stop looking around 
            startDialogue.SetActive(true);
        }
    }

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
                Debug.Log("F key pressed");
                Cursor.lockState = CursorLockMode.None;
                //MouseLook.   find a way to switch bool indialogue to off in mouselook script to stop looking around 
                startDialogue.SetActive(true);
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


}
