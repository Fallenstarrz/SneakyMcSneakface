using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPawn : Pawn
{
    public override void Start()
    {
        GameManager.instance.guards.Add(this.gameObject);
        base.Start();
    }
    public override void OnDestroy()
    {
        GameManager.instance.guards.Remove(this.gameObject);
    }
    public override void stateIdle()
    {
        base.stateIdle();
    }
    public override void statePursue()
    {
        base.statePursue();
    }
    public override void stateReset()
    {
        base.stateReset();
    }
    public override void stateAttack()
    {
        base.stateAttack();
    }
    public override void move()
    {
        base.move();
    }
    public override void rotate()
    {
        base.rotate();
    }
    public override void attack()
    {
        attackCooldownCurrent = attackCooldown;
        noiseMaker.noiseLevel = 4.0f;
        Debug.Log("I am a guard attacking");
    }
    public override void updateTarget()
    {
        targetPosition = target.transform.position;
    }
    public override void updateHealth()
    {

    }
}
