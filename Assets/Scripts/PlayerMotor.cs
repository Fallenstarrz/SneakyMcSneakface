using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    public int playerMoveSpeed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0,Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed, 0);
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed, 0, 0);
    }
}
