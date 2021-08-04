using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Enum, like bool, can only be true or falase. Will only have 1 active
public enum PlayerState
{
  walk,
  attack,
  interact,
  death
}

public class PlayerMovement : MonoBehaviour
{

public PlayerState currentState;
	public float speed;
	private Rigidbody2D myRigidbody;
	private Vector3 change;

  private Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
      myRigidbody = GetComponent<Rigidbody2D>();
      animator.SetFloat("moveX", 0);
      animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("attack") && currentState != PlayerState.attack)
        {
          StartCoroutine(AttackCo());
        }
        //Won't Run unless ^^^ runs
        else if(currentState == PlayerState.walk)
        {
        UpdateAnimationandMove();
        }
    }
    //Runs at the same time as main process, holds values with delay
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;
    }

    //Method to Call Walk Animations
    void UpdateAnimationandMove()
    {
      if(change != Vector3.zero)
        {
          MoveCharacter();
          animator.SetFloat("moveX", change.x);
          animator.SetFloat("moveY", change.y);
          animator.SetBool("moving", true);
        }
        else
        {
          animator.SetBool("moving", false);
        }
    }


    //Method to Determine Speed of Player
    void MoveCharacter()
    {
      change.Normalize();
      myRigidbody.MovePosition(
        transform.position + change.normalized * speed * Time.fixedDeltaTime);

    }
}
