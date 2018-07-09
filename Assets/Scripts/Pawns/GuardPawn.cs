using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardPawn : Pawn
{
    //Run our own start then our parents start
    public override void Start()
    {
        GameManager.instance.guards.Add(this.gameObject);

        // Set currentHealth to maxHealth at Start
        currentHealth = maxHealth;

        base.Start();
    }
    //when destroyed run this
    public override void OnDestroy()
    {
        GameManager.instance.guards.Remove(this.gameObject);
    }
    // Run parents Idle state
    public override void stateIdle()
    {
        base.stateIdle();
    }
    // run parents pursue state
    public override void statePursue()
    {
        base.statePursue();
    }
    // run parents reset state
    public override void stateReset()
    {
        base.stateReset();
    }
    // run parents attack state
    public override void stateAttack()
    {
        base.stateAttack();
    }
    // run parents move function
    public override void move()
    {
        base.move();
    }
    // run parents rotate function
    public override void rotate()
    {
        base.rotate();
    }
    // run our own attack function, so it isn't a generic attack
    public override void attack()
    {
        attackCooldownCurrent = attackCooldown;
        noiseMaker.noiseLevel = 4.0f;
        Debug.Log("I am a guard attacking");
        dealDamage();
    }
    // run our own updateTarget, so we don't accidently set target for all pawn types
    public override void updateTarget()
    {
        targetPosition = target.transform.position;
    }
    // run our own updateHealth so we can return our own health versus accidently getting someone elses health
    public override float updateHealth()
    {
        return currentHealth;
    }
    // run parents dealDamage function
    public override void dealDamage()
    {
        base.dealDamage();
    }
    // run our own takeDamage, so we can set our own health and reduce it by the damage passed into the function
    public override void takeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
    }
}
