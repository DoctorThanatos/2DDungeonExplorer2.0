using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAI : EnemyAI
{

    //Transform stores information about location; position, rotation, scale
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    //Function to Find Difference Between Log and Target
    void CheckDistance()
    {
        if(Vector2.Distance(target.position, transform.position) <=chaseRadius
                            && Vector2.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //Attack Radius as last variable for funnies

        }

    }
}
