using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Vector3 PlayerVertical, MovementRight, MovementLeft;
    public float MoveSpeed, TurnSpeed;
    public KeyCode Right, Left, Front, Back;
    Rigidbody PlayerRot;

    void Start()
    {
        PlayerRot = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey(Left))
        {
        PlayerRot.AddTorque(-Vector3.up * TurnSpeed);
        }


        if(Input.GetKey(Right))
        {
            PlayerRot.AddTorque(Vector3.up * TurnSpeed);
            //PlayerRot.MoveRotation(PlayerRot.rotation * deltaRotation );
        }
        if(Input.GetKey(Front))
        {
        // Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //PlayerRot.MovePosition(transform.position + PlayerVertical); //velocity += PlayerVertical;
            PlayerRot.AddRelativeForce(Vector3.forward * MoveSpeed);
        }
            
        if(Input.GetKey(Back))
            //GetComponent<Rigidbody>().velocity -= PlayerVertical;
            PlayerRot.AddRelativeForce(-Vector3.forward * MoveSpeed);
    }
    
}
