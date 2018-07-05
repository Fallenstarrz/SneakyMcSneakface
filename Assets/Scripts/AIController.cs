using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    public int moveSpeed;
    public int rotationSpeed;
    public Vector3 spawnPosition;
    public int currentState;

    enum states
    {
        idle,
        pursue,
        reset,
        attack,
        dead
    };

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	protected override void Update ()
    {

	}
}
