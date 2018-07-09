using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
       offset = transform.position - GameManager.instance.player.transform.position;
	}
	
    // Tells camera to follow whatever is stored in the player.transform.position
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = GameManager.instance.player.transform.position + offset;
    }
}
