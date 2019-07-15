using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovmentFisch : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public float movementSpeed;
    public float startWaitTime;
    public float speed;

    private float waitTime;

    public Transform[] FischWaypoints;
    public Transform central;
    private int Spot;
    

    void Start()
    {
        waitTime = startWaitTime;
        Spot = Random.Range(0, FischWaypoints.Length);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Update()
    {
        FaceTarget();
    }
    void FaceTarget()
    {
        Vector3 direction = (FischWaypoints[Spot].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}


// Use this for initialization
/*void Start()
{
    waitTime = startWaitTime;
    Spot = Random.Range(0,FischWaypoints.Length);
}
void Update()
{
    transform.position = Vector3.MoveTowards(transform.position, FischWaypoints[Spot].position, movementSpeed * Time.deltaTime);
    transform.LookAt(FischWaypoints[Spot]);

    if (Vector3.Distance(transform.position, FischWaypoints[Spot].position) < 0.2f)
    {
        if (waitTime <= 0)
        {
            Spot = Random.Range(0, FischWaypoints.Length);
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
}*/
