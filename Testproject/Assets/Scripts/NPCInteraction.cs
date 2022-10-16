using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject startDialogue = null;

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
    
}
