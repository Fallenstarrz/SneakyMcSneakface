using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPawn : Pawn
{
    // get reference to our screen widget for healthbar
    public Slider healthBar;

    public void Awake()
    {

    }
    // DO this dungtion then pawn.start
    public override void Start()
    {
        GameManager.instance.player = this.gameObject;

        // Set currentHealth to maxHealth at Start
        currentHealth = maxHealth;

        // Set gui health
        healthBar.value = updateHealth();

        base.Start();
    }
    // we don't use this for player right now, but also don't want to use parent, so we override it
    public override void OnDestroy()
    {

    }
    // we don't use this for player right now, but also don't want to use parent, so we override it
    public override void stateIdle()
    {

    }
    // we don't use this for player right now, but also don't want to use parent, so we override it
    public override void statePursue()
    {

    }
    // we don't use this for player right now, but also don't want to use parent, so we override it
    public override void stateReset()
    {

    }
    // we don't use this for player right now, but also don't want to use parent, so we override it
    public override void stateAttack()
    {

    }
    // we don't use this for player right now, but also don't want to use parent, so we override it
    public override void move()
    {
        
    }
    // we don't use this for player right now, but also don't want to use parent, so we override it
    public override void rotate()
    {
        
    }
    // we override the parent function, so we can sue our own. We send in moveDirection from playerController to control movement
    public override void move(float moveDirection)
    {
        noiseMaker.noiseLevel = 2.0f;
        transform.Translate(0, moveDirection * Time.deltaTime * moveSpeed, 0);
    }
    // we override the parent function, so we can use our own. We send in rotateDirection from playerController to control movement
    public override void rotate(float rotateDirection)
    {
        noiseMaker.noiseLevel = 1.0f;
        transform.Rotate(0, 0, rotateDirection * Time.deltaTime * rotationSpeed);
    }
    // use our own attack function, so we can say we are a player attacking instead of a base.Pawn or a guard etc...
    public override void attack()
    {
        noiseMaker.noiseLevel = 4.0f;
        dealDamage();
        Debug.Log("I am a player attacking");
    }
    // Do nothing
    public override void updateTarget()
    {
        
    }
    // update our health for the slider widget to use for display
    public override float updateHealth()
    {
        return currentHealth / maxHealth;
    }
    // We don't currently allow the player to fight, it actually made it more fun to dodge zombies than to fight them
    public override void dealDamage()
    {
        
    }
    // We use our own take damage because we want to control what happens when this specific object dies.
    public override void takeDamage(int damageToTake)
    {
        currentHealth -= damageToTake;
        healthBar.value = updateHealth();

        if (currentHealth <= 0)
        {
            GameManager.instance.sceneScript.LoadCredits();
        }
    }
}
