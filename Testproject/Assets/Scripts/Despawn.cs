using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{

    [SerializeField] private GameObject GameOver = null;
    [SerializeField] private GameObject talkSign = null;
    [SerializeField] private GameObject captureSign = null;
    public playerController playerController;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        if (other.gameObject.tag == "Enemy")
        {
            playerController.isInteracting = true;
            talkSign.SetActive(false);
            captureSign.SetActive(false);
            GameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
