using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInteraction : MonoBehaviour
{
    [SerializeField] private GameObject startDialogue = null;
    [SerializeField] private GameObject angryDialogue = null;
    [SerializeField] private GameObject victory = null;
    [SerializeField] private GameObject talkSign = null;
    [SerializeField] private GameObject captureSign = null;
    public bool happy = true;
    NavMeshAgent agent;
    public playerController playerController;

    public Transform Escape;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (happy == true)
            {
                captureSign.SetActive(false);
                talkSign.SetActive(true);
            }
            else if (happy == false)
            {
                talkSign.SetActive(false);
                captureSign.SetActive(true);
            }

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                playerController.isInteracting = true;
                agent.speed = 0f;
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
                    victory.SetActive(true);
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerController.isInteracting = false;
            talkSign.SetActive(false);
            captureSign.SetActive(false);
            startDialogue.SetActive(false);
            angryDialogue.SetActive(false);
            enemyMove();



            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void EnemyRunAway()
    {
        happy = false;
        Debug.Log("npc is unhappy now");
        agent.SetDestination(Escape.position);
        enemyMove();
    }
    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void EnableAgent()
    {
        agent.enabled = true;
    }

    public void enemyMove()
    {
        agent.speed = 3.5f;
    }


}
