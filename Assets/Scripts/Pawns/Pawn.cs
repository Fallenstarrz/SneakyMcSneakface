using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Pawn specific variables
    [SerializeField] protected int moveSpeed;
    [SerializeField] protected int rotationSpeed;
    [SerializeField] protected Vector3 spawnPosition;
    [SerializeField] protected float attackRange;
    [SerializeField] protected int damage;
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected int health;
    protected float attackCooldownCurrent;

    // Link Controller to pawn
    protected Controller controller;

    // Target
    [SerializeField] protected Transform target;
    protected Vector3 targetPosition;
    
    // Pawn Senses
    protected LineOfSight sight;
    protected Hearing hearing;
    protected NoiseMaker noiseMaker;
    protected Hitbox hitbox;

    public virtual void Start()
    {
        // set spawn position to the position they were placed in at runtime
        spawnPosition = gameObject.transform.position;

        targetPosition = spawnPosition;

        // Link the controller to this pawn
        controller = GetComponent<Controller>();

        // set senses to the gameObject
        sight = GetComponent<LineOfSight>();
        hearing = GetComponent<Hearing>();
        noiseMaker = GetComponent<NoiseMaker>();
        hitbox = GetComponent<Hitbox>();
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
        if (sight.inLineOfSight())
        {
            targetPosition = sight.target.transform.position;
            controller.currentState = Controller.AIStates.pursue;
        }
        if (hearing.listenForNoise())
        {
            targetPosition = hearing.targetNoiseMaker.gameObject.transform.position;
            controller.currentState = Controller.AIStates.pursue;
        }
    }
    public virtual void statePursue()
    {
        move();
        rotate();
        updateTarget();
        if (sight.inLineOfSight() == false || hearing.listenForNoise() == false)
        {
            controller.currentState = Controller.AIStates.idle;
        }
        if (Vector3.Distance(targetPosition, transform.position) < attackRange )
        {
            controller.currentState = Controller.AIStates.attack;
        }
    }
    public virtual void stateReset()
    {
        targetPosition = spawnPosition;
        move();
        rotate();
        if (gameObject.transform.position == spawnPosition)
        {
            controller.currentState = Controller.AIStates.idle;
        }
    }
    public virtual void stateAttack()
    {
        if (attackCooldownCurrent <= 0)
        {
            attack();
            updateTarget();
        }
        attackCooldownCurrent -= Time.deltaTime;
        if (Vector3.Distance(targetPosition, transform.position) > attackRange)
        {
            controller.currentState = Controller.AIStates.pursue;
        }
    }
    public virtual void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed*Time.deltaTime);
        noiseMaker.noiseLevel = 2.0f;
    }
    public virtual void move(float moveDirection)
    {

    }
    public virtual void rotate()
    {
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();
        float zAngle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        Quaternion targetLocation = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLocation, rotationSpeed * Time.deltaTime);

        noiseMaker.noiseLevel = 1.0f;
    }
    public virtual void rotate(float rotateDirection)
    {

    }
    public virtual void attack()
    {
        noiseMaker.noiseLevel = 4.0f;
        Debug.Log("I am a basePawn attacking");
    }
    public virtual void updateTarget()
    {
        targetPosition = target.transform.position;
    }
}
