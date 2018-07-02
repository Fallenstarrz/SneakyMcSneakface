using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private Vector3 offset;

	// Use this for initialization
	void Start ()
    {
       //offset = transform.position - playerTransform.position;
       offset = transform.position - GameManager.instance.player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = GameManager.instance.player.transform.position + offset;
    }
}
