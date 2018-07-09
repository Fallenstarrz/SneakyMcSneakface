using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPawn : MonoBehaviour {

    public Text pawnName;
    private Vector3 offset;
    public Transform target;

    // sets nameplate to be above pawns

    // Use this for initialization
    void Start()
    {
        //offset is how high above our target we want the nameplate to be
        offset = new Vector3 (0 , 0.5f, 0);
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
