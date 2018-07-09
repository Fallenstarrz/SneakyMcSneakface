﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPawn : Pawn
{
    public Slider healthBar;

    public void Awake()
    {

    }
    public override void Start()
    {
        GameManager.instance.player = this.gameObject;

        // Set currentHealth to maxHealth at Start
        currentHealth = maxHealth;

        // Set gui health
        healthBar.value = updateHealth();

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
    public override void move()
    {
        
    }
    public override void rotate()
    {
        
    }
    public override void move(float moveDirection)
    {
        noiseMaker.noiseLevel = 2.0f;
        transform.Translate(0, moveDirection * Time.deltaTime * moveSpeed, 0);
    }
    public override void rotate(float rotateDirection)
    {
        noiseMaker.noiseLevel = 1.0f;
        transform.Rotate(0, 0, rotateDirection * Time.deltaTime * rotationSpeed);
    }
    public override void attack()
    {
        noiseMaker.noiseLevel = 4.0f;
        dealDamage();
        Debug.Log("I am a player attacking");
    }
    public override void updateTarget()
    {
        
    }
    public override float updateHealth()
    {
        return currentHealth / maxHealth;
    }
    public override void dealDamage()
    {
        
    }
    public override void takeDamage(int damageToTake)
    {
        Debug.Log("I took damage!");
        currentHealth -= damageToTake;
        healthBar.value = updateHealth();

        if (currentHealth <= 0)
        {
            GameManager.instance.currentGameState = GameManager.IGameState.Credits;
        }
    }
}
