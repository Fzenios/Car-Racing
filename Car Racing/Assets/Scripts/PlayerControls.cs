using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public float MoveSpeed, BackSpeed, BreakSpeed, TurnSpeed, CantTurn;
    public float Gear0, Gear1, Gear2, Gear3, Gear4;
    public KeyCode Right, Left, Front, Back, Brake;
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
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0f);
    }
    void Update() 
    {
        SpeedCurrent = PlayerRb.velocity.magnitude * 3.6f;
        SpeedTxt.text = SpeedCurrent + " km/h";
        AccelerationCheck();
        RotateCheck();
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
            PlayerRb.AddRelativeForce(-Vector3.forward * BackSpeed);
        }
        if(Input.GetKey(Brake))
        {
            MoveSpeed = BreakSpeed;
            BackSpeed = BreakSpeed;
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
    void AccelerationCheck()
    {
        if(!Input.GetKey(Brake))
        {
            if(SpeedCurrent < 170)
                MoveSpeed = Gear1;
            if(SpeedCurrent > 170)
                MoveSpeed = Gear2;

            BackSpeed = Gear0;
        }
    }
    void RotateCheck()
    {       
        if(transform.rotation.eulerAngles.z > 88 && transform.rotation.eulerAngles.z < 180 )
        {
            transform.Rotate(0,0,-50f);
            
        }
        if(transform.rotation.eulerAngles.z > 181 && transform.rotation.eulerAngles.z <= 272 )
        {
            transform.Rotate(0,0,50); 
        }
    }
    
}