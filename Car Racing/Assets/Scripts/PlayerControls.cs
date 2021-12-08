using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public float MoveSpeed, TurnSpeed, CantTurn;
    public KeyCode Right, Left, Front, Back;
    Rigidbody PlayerRb;
    float distToGround;
    public Text SpeedTxt;
    public float SpeedCurrent;

    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        Collider collider = GetComponent<Collider>();
        distToGround = collider.bounds.extents.y;
    }
    bool IsGrounded() 
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 100.5f);
    }
    void Update() 
    {
        SpeedCurrent = PlayerRb.velocity.magnitude * 3.6f;
        SpeedTxt.text = SpeedCurrent + " km/h";
    }

    void FixedUpdate()
    {
        if(IsGrounded())
        {
            PlayerForward();
            if(SpeedCurrent > CantTurn)
                PlayerTurn();
        }
    }
    void PlayerForward()
    {
        if(Input.GetKey(Front))
        {
            PlayerRb.AddRelativeForce(Vector3.forward * MoveSpeed);
        }    
        if(Input.GetKey(Back))
        {
            PlayerRb.AddRelativeForce(-Vector3.forward * MoveSpeed);
        }
        
        /*Vector3 LocalVelocity = transform.InverseTransformDirection(PlayerRb.velocity);
        LocalVelocity.x = 0;
        PlayerRb.velocity = transform.TransformDirection(LocalVelocity);*/
    }
    void PlayerTurn()
    {
        if(Input.GetKey(Left))
        {
            PlayerRb.AddTorque(-Vector3.up * TurnSpeed);
        }
        if(Input.GetKey(Right))
        {
            PlayerRb.AddTorque(Vector3.up * TurnSpeed);
        }
    }
    
}
