using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowerController : MonoBehaviour
{
    public Transform targetPosition;
    protected NavMeshAgent followerMesh;
    // Start is called before the first frame update
    void Start()
    {
        followerMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        followerMesh.SetDestination(targetPosition.position);
    }
}
