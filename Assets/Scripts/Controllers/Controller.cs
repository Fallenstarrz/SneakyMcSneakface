﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected Pawn pawn;

    protected float moveDirection;
    protected float rotateDirection;

    public enum AIStates
    {
        idle,
        pursue,
        reset,
        attack,
        dead

    };
    [SerializeField]
    public AIStates currentState;

    // Use this for initialization
    protected virtual void Start()
    {
        pawn = GetComponent<Pawn>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        switch (currentState)
        {
            case AIStates.idle:
                //Idle State
                pawn.stateIdle();
                break;

            case AIStates.pursue:
                //Pursue State
                pawn.statePursue();
                break;

            case AIStates.reset:
                //Reset State
                pawn.stateReset();
                break;

            case AIStates.attack:
                //Attack State
                pawn.stateAttack();
                break;
        }
    }

}
