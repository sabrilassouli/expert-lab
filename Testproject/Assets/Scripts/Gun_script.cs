using UnityEngine;

public class Gun_script : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;
    playerController playerController;
    public GameController gameController;

    public AudioSource gunshot;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //if (playerController.isInteracting == false)
            //{
            shoot();
            gameController.currentscore -= 100;
            //}
        }
    }
    void shoot()
    {
        muzzleflash.Play();
        gunshot.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) ;
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
