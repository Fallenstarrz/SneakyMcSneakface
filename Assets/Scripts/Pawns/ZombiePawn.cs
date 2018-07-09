using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombiePawn : Pawn
{
    // Zombie start, set health, add to gameManager list and then call Pawn.Start
    public override void Start()
    {
        GameManager.instance.zombies.Add(this.gameObject);

        // Set currentHealth to maxHealth at Start
        currentHealth = maxHealth;

        base.Start();
    }
    // Remove from gamemanager when destroyed
    public override void OnDestroy()
    {
        GameManager.instance.zombies.Remove(this.gameObject);
    }
    // use parent stateIdle
    public override void stateIdle()
    {
        base.stateIdle();
    }
    // use parent statePursue
    public override void statePursue()
    {
        base.statePursue();
    }
    // use Parent stateReset
    public override void stateReset()
    {
        base.stateReset();
    }
    //use Parent stateAttack
    public override void stateAttack()
    {
        base.stateAttack();
    }
    // use Parent move
    public override void move()
    {
        base.move();
    }
    // use parent rotate
    public override void rotate()
    {
        base.rotate();
    }
    // set personal attack cooldown and call deal damage function
    public override void attack()
    {
        attackCooldownCurrent = attackCooldown;
        noiseMaker.noiseLevel = 4.0f;
        Debug.Log("I am a Zombie Attacking");
        dealDamage();
    }
    // get new target position
    public override void updateTarget()
    {
        targetPosition = target.transform.position;
    }
    // update health, we will use Parent because we don't want to rewrite it for guard too
    public override float updateHealth()
    {
        return currentHealth;
    }
    // deal damage, we will use parent here too
    public override void dealDamage()
    {
        base.dealDamage();
    }
    // set health equal to itself minus damage to take that is passed in by the agressor.
    public override void takeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
    }
}
