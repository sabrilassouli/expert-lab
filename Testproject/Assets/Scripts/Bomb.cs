using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] private GameObject InteractSign = null;

    [SerializeField] private GameObject bomb = null;

    public GameController gameController;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractSign.SetActive(true);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                bomb.SetActive(false);
                InteractSign.SetActive(false);
                gameController.remainingBombs -= 1;
                gameController.currentscore += 1000;

            }
        }
    }
}
