using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Target : MonoBehaviour
{
    NavMeshAgent agent;
    public GameController gameController;

    public bool isInnocent = true;
    [SerializeField] private GameObject GunGameOverDialogue = null;
    [SerializeField] private GameObject TazerGameOverDialogue = null;
    [SerializeField] private GameObject HandcuffGameOverDialogue = null;
    public playerController playerController;


    // Start is called before the first frame update
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (isInnocent == false)
        {
            Destroy(gameObject);
            gameController.currentscore += 50;
            gameController.remainingTargets -= 1;
            Debug.Log(gameController.currentscore);
        }
        else if (isInnocent == true)
        {
            Cursor.lockState = CursorLockMode.None;
            playerController.isInteracting = true;
            playerController.talking();
            GunGameOverDialogue.SetActive(true);
        }
    }


    public void Tazed()
    {
        if (isInnocent == false)
        {
            agent.speed = 0f;
            StartCoroutine(WaitforSomeSecondsPleaase());
            gameController.currentscore += 100;
            Debug.Log(gameController.currentscore);
        }
        else if (isInnocent == true)
        {
            TazerGameOverDialogue.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            playerController.isInteracting = false;
        }
    }
    public void Arrested()
    {
        if (isInnocent == false)
        {
            agent.speed = 0f;
            //GameController.Victory();        
            Destroy(gameObject);
            gameController.currentscore += 1000;
            gameController.remainingTargets -= 1;
            Debug.Log(gameController.currentscore);
        }
        else if (isInnocent == true)
        {
            HandcuffGameOverDialogue.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            playerController.isInteracting = false;
        }
    }

    IEnumerator WaitforSomeSecondsPleaase()
    {
        yield return new WaitForSeconds(5);
        agent.speed = 3.5f;
    }
}
