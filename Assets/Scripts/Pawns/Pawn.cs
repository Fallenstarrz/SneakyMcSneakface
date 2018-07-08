using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Pawn specific variables
    [SerializeField]
    protected int moveSpeed;
    [SerializeField]
    protected int rotationSpeed;
    [SerializeField]
    protected Vector3 spawnPosition;

    // Link Controller to pawn
    protected Controller controller;
    
    // Pawn Senses
    protected LineOfSight sight;
    protected Hearing hearing;
    protected NoiseMaker noiseMaker;
    protected Hitbox hitbox;
    protected AttackRange attackRange;

    public virtual void Start()
    {
        // set spawn position to the position they were placed in at runtime
        spawnPosition = gameObject.transform.position;

        // Link the controller to this pawn
        controller = GetComponent<Controller>();

        // set senses to the gameObject
        sight = GetComponent<LineOfSight>();
        hearing = GetComponent<Hearing>();
        noiseMaker = GetComponent<NoiseMaker>();
        hitbox = GetComponent<Hitbox>();
        attackRange = GetComponent<AttackRange>();
    }
    public virtual void OnDestroy()
    {

    }
    public virtual void stateIdle()
    {

        if (gameObject.transform.position != spawnPosition)
        {
            controller.currentState = Controller.AIStates.reset;
        }
        // WE NEED TO GET RID OF THIS TO TEST HEARING!!!
        if (sight.inLineOfSight())
        {
            //controller.currentState = Controller.AIStates.pursue;
        }
        //if ()
        //{
        //    // WE CHECK HEARING HERE!

              // If hearing triggered
              // currentState = pursue
        //}
    }
    public virtual void statePursue()
    {
        // Get player position
        // slerp ai position to player position
        // if player not in sight or hearing
        // currentState = reset
        // if player in attack range
        // current state = attack
    }
    public virtual void stateReset()
    {
        move();
        rotate();
        if (gameObject.transform.position == spawnPosition)
        {
            controller.currentState = Controller.AIStates.idle;
        }
    }
    public virtual void stateAttack()
    {
        // deal dmg to player
        // if player not in attack range
        // current state = pursue
    }
    public virtual void stateDead()
    {
        Destroy(this.gameObject);
    }
    public virtual void move()
    {
       transform.position = Vector2.MoveTowards(transform.position, spawnPosition, moveSpeed*Time.deltaTime); // Replace spawnPosition with target, and change target in reset to spawnpoint
    }
    public virtual void move(float moveDirection)
    {

    }
    public virtual void rotate()
    {
        transform.LookAt(spawnPosition); // Replace spawnPosition with target, and change target in reset to spawnpoint
    }
    public virtual void rotate(float rotateDirection)
    {

    }
    public virtual void attack()
    {
        Debug.Log("I am a basePawn attacking");
    }
}
