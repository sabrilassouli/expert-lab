using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Handcuffs : MonoBehaviour
{

    public float damage = 0f;
    public float range = 2f;

    public Camera fpsCam;
    playerController playerController;

    public AudioSource cuffSound;
    NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //if (playerController.isInteracting == false)
            //{
            Arrest();
            //}
        }
    }
    void Arrest()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) ;
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Arrested();
            }
        }
    }
}
