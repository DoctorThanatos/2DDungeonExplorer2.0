using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if(enemy != null)
            {
                enemy.GetComponent<EnemyInheritance>().currentState = EnemyState.stagger;
                StartCoroutine(KnockCoroutine(enemy));
            }
        }
    }
        private IEnumerator KnockCoroutine(Rigidbody2D enemy)
        {
            Vector2 forceDirection = enemy.transform.position - transform.position;
            Vector2 force = forceDirection.normalized * thrust;

            enemy.velocity = force;
            yield return new WaitForSeconds(.3f);
            enemy.GetComponent<EnemyInheritance>().currentState =EnemyState.idle;

            enemy.velocity = new Vector2();
        }
}