using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Vector3 PlayerVertical, PlayerHorizontal;
    public KeyCode Right, Left, Front, Back;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(Left))
            GetComponent<Rigidbody>().velocity -= PlayerHorizontal;
        if(Input.GetKey(Right))
            GetComponent<Rigidbody>().velocity += PlayerHorizontal;
        if(Input.GetKey(Front))
            GetComponent<Rigidbody>().velocity += PlayerVertical;
        if(Input.GetKey(Back))
            GetComponent<Rigidbody>().velocity -= PlayerVertical;

    }
}
