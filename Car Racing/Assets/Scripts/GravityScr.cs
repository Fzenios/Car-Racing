using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScr : MonoBehaviour
{
    CharacterController controller;
    float VerticalVelocity;
    //public float Gravity = 14f;
    public Vector3 sumve;
    //public bool SimpleMove(sumve 3);
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //sumve = new Vector3(1,0,0);
    }
    void Update()
    {
        controller.SimpleMove(sumve * Time.deltaTime);
       /* if(controller.isGrounded)
        {
            VerticalVelocity = -Gravity * Time.deltaTime;
        }
        else
        {
            VerticalVelocity -= Gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0,VerticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);*/


    }
}
