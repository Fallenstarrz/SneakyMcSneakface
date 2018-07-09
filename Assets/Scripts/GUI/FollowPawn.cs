﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPawn : MonoBehaviour {

    public Text pawnName;
    private Vector3 offset;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        //offset = transform.position - playerTransform.position;
        offset = transform.position - target.position;
        pawnName.text = target.gameObject.name;
        if (target.gameObject.name == "Zombie")
        {
            pawnName.color = Color.red;
        }
        if (target.gameObject.name == "Guard")
        {
            pawnName.color = Color.yellow;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
