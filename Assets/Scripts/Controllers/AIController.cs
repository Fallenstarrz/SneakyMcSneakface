using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    // Set state to idle on start then run base.Start to grab a pawn to possess
	// Use this for initialization
	protected override void Start ()
    {
        currentState = AIStates.idle;

        base.Start();
	}
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();
	}
}
