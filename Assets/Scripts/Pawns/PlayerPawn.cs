using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
{
    public void Awake()
    {

    }
    public override void Start()
    {
        GameManager.instance.player = this.gameObject;
        base.Start();
    }
    public override void OnDestroy()
    {

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
    public override void move(float moveDirection)
    {
        transform.Translate(0, moveDirection * Time.deltaTime * moveSpeed, 0);
    }
    public override void rotate(float rotateDirection)
    {
        transform.Rotate(0, 0, rotateDirection * Time.deltaTime * rotationSpeed);
    }
    public override void attack()
    {
        Debug.Log("I am a player attacking");
    }
}
