using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    public int playerMoveSpeed;
    public int playerRotationSpeed;

	// Use this for initialization
	void Start ()
    {
        GameManager.instance.player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(0,Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed, 0);
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * Time.deltaTime * playerRotationSpeed);
    }
}
