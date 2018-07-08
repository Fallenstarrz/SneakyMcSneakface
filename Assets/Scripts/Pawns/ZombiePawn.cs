using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePawn : Pawn
{
    public override void Start()
    {
        GameManager.instance.zombies.Add(this.gameObject);
        base.Start();
    }
    public override void OnDestroy()
    {
        GameManager.instance.zombies.Remove(this.gameObject);
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
    public override void stateDead()
    {
        base.stateDead();
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
        Debug.Log("I am a Zombie attacking");
    }
}
