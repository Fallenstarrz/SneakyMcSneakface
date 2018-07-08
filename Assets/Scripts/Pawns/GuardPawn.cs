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

    }
    public override void statePursue()
    {

    }
    public override void stateReset()
    {

    }
    public override void stateAttack()
    {

    }
    public override void stateDead()
    {
        base.stateDead();
    }
    public override void move()
    {

    }
    public override void rotate()
    {

    }
    public override void attack()
    {
        Debug.Log("I am a guard attacking");
    }
}
