using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Target : MonoBehaviour
{
    NavMeshAgent agent;

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
        Destroy(gameObject);
    }


    public void Tazed()
    {
        agent.speed = 0f;
        StartCoroutine(WaitforSomeSecondsPleaase());

    }
    public void Arrested()
    {
        agent.speed = 0f;
        //GameController.Victory();

    }

    IEnumerator WaitforSomeSecondsPleaase()
    {
        yield return new WaitForSeconds(5);
        agent.speed = 3.5f;
    }
}
