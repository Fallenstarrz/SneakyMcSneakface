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
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float maxHealth;
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
        spawnPosition = transform.position;

        targetPosition = spawnPosition;

        // Link the controller to this pawn
        controller = GetComponent<Controller>();

        // set senses to the gameObject
        sight = GetComponent<LineOfSight>();
        hearing = GetComponent<Hearing>();
        noiseMaker = GetComponent<NoiseMaker>();
        hitbox = GetComponent<Hitbox>();
    }
    // We don't destroy anything in this game, so we left this blank
    public virtual void OnDestroy()
    {

    }
    // This is the idle state, it stands still and waits for something to tell it to swap to a different state.
    public virtual void stateIdle()
    {

        if (transform.position != spawnPosition)
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
    // this is the prusue state, it will chase its current target until it is told to leave the state
    public virtual void statePursue()
    {
        move();
        rotate();
        updateTarget();
        if (sight.inLineOfSight() == false && hearing.listenForNoise() == false)
        {
            controller.currentState = Controller.AIStates.idle;
        }
        if (Vector3.Distance(targetPosition, transform.position) < attackRange )
        {
            controller.currentState = Controller.AIStates.attack;
        }
    }
    // This is the reset state it will go back to its spawn position when we enter this state.
    public virtual void stateReset()
    {
        targetPosition = spawnPosition;
        move();
        rotate();
        if (transform.position == spawnPosition)
        {
            controller.currentState = Controller.AIStates.idle;
        }
    }
    // This is our attack state, we will go here when told and deal damage when conditions are met
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
    // move, all none-player pawns will use this
    public virtual void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed*Time.deltaTime);
        noiseMaker.noiseLevel = 2.0f;
    }
    // move overload, we don't use this for anything but the player
    public virtual void move(float moveDirection)
    {

    }
    // rotate, all none-player pawns will use this to rotate
    public virtual void rotate()
    {
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();
        float zAngle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        Quaternion targetLocation = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLocation, rotationSpeed * Time.deltaTime);

        noiseMaker.noiseLevel = 1.0f;
    }
    // rotate overload, we don't use this for anything but the player
    public virtual void rotate(float rotateDirection)
    {

    }
    // attack function, it makes a noise. That is it for now...
    public virtual void attack()
    {
        noiseMaker.noiseLevel = 4.0f;
        Debug.Log("I am a basePawn attacking");
    }
    // this function updates the targets position
    public virtual void updateTarget()
    {
        targetPosition = target.transform.position;
    }
    // this function just returns current health for now.
    public virtual float updateHealth()
    {
        return currentHealth;
    }
    // This function sends the damage number to the takeDamage function
    public virtual void dealDamage()
    {
        target.gameObject.GetComponent<Pawn>().takeDamage(damage);
    }
    //This function takes in damage and reduces current health by that damage
    public virtual void takeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
    }
}
