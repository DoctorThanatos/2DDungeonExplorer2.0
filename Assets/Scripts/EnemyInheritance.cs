using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    idle,
    walk, 
    attack,
    stagger

}
public class EnemyInheritance : MonoBehaviour
{
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
  
   public void Knock(Rigidbody2D myRigidBody, float knockTime)
   {
       StartCoroutine(KnockCoroutine(myRigidBody, knockTime));
   }
   
   private IEnumerator KnockCoroutine(Rigidbody2D myRigidbody, float knockTime)
        {
            if(myRigidbody != null)
            {
                yield return new WaitForSeconds(knockTime);
                myRigidbody.velocity = Vector2.zero;
                currentState = EnemyState.idle;
                myRigidbody.velocity = Vector2.zero;
            }
            
            //Solution to Issue From Comments
            //Vector2 forceDirection = hit.transform.position - transform.position;
            //Vector2 force = forceDirection.normalized * thrust;

            //hit.velocity = force;
            //yield return new WaitForSeconds(.3f);
            //hit.GetComponent<EnemyInheritance>().currentState =EnemyState.idle;

            //hit.velocity = new Vector2();
        }
}
