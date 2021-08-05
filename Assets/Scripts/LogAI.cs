using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAI : EnemyInheritance
{

    //Transform stores information about location; position, rotation, scale
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    //Function to Find Difference Between Log and Target
    void CheckDistance()
    {
        if(Vector2.Distance(target.position, transform.position) <=chaseRadius
                            && Vector2.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk
                            && currentState != EnemyState.stagger)
            {
            Vector2 temp = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            //Attack Radius as last variable for funnies

            myRigidBody.MovePosition(temp);
            ChangeState(EnemyState.walk);
            }

        }

    }
    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }

    }
}
