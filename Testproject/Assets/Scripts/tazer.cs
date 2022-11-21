using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tazer : MonoBehaviour
{
    public float damage = 0f;
    public float range = 10f;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;
    playerController playerController;

    public AudioSource tazersound;    
    NavMeshAgent agent;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //if (playerController.isInteracting == false)
            //{
            Taze();
            //}
        }
    }

    void Taze()
    {
        muzzleflash.Play();
        tazersound.Play();
         RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) ;
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Tazed();
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }

    }

}
