using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{

    public float movementSpeed;
    public float startWaitTime;
    public float speed;

    private float waitTime;

    public Transform[] moveSpots;
    public Transform central;
    private int Spot;
    
    

    // Use this for initialization
    void Start()
    {
        waitTime = startWaitTime;
        Spot = 0;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[Spot].position,movementSpeed *Time.deltaTime);
        transform.LookAt(central);

        if (Vector3.Distance(transform.position, moveSpots[Spot].position) < 0.2f)
        {
            if(waitTime <= 0)   
            {
                if (moveSpots.Length-1 == Spot)
                {
                    Spot = 0;
                }
                else
                {
                    Spot++;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
