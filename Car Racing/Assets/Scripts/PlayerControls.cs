using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    public float MoveSpeed, BackSpeed, BrakeSpeed, TurnSpeed, CantTurn;
    public float Gear0, Gear1, Gear2, Gear3, Gear4, Gear5;
    public KeyCode Right, Left, Front, Back, Brake, Lights;
    public Rigidbody PlayerRb;
    float distToGround;
    public TMP_Text SpeedTxt, GearTxt;
    public float SpeedCurrent;
    public bool CanMove;
    public GameObject CarLights;
    public GameScr gameScr;
    public Animator animator;
    public int CurrentGear;
    public GameObject Backlights;
    public SoundsScr soundsScr;
    public PauseMenu pauseMenu;

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
        SpeedTxt.text = SpeedCurrent.ToString("0");
        if(CurrentGear > 0)
            GearTxt.text = "Gear " + CurrentGear;
        else if(CurrentGear == 0 && SpeedCurrent > 1)
            GearTxt.text = "Gear R";
        else if(CurrentGear == 0 && SpeedCurrent < 1)
            GearTxt.text = "Gear N";

        RotateCheck();
        LightsCheck();
        animator.SetFloat("Speed", SpeedCurrent);

        if(Input.GetKeyDown(Front) && !pauseMenu.PauseGame)
            soundsScr.Engine("Play");
        soundsScr.Sounds[1].source.pitch = (PlayerRb.velocity.magnitude / 75) * 3;
    }

    void FixedUpdate()
    {
        if(CanMove)
        {
            if(IsGrounded())
            {
                PlayerForward();
                GearSystem();
                if(SpeedCurrent > CantTurn)
                    PlayerTurn();
            }
        }
    }
    void PlayerForward()
    {
        if(!Input.GetKey(Front) || !Input.GetKey(Back))
        {
            if(Input.GetKey(Front))
            {
                PlayerRb.AddRelativeForce(Vector3.forward * MoveSpeed);
            }    
            if(Input.GetKey(Back))
            {
                PlayerRb.AddRelativeForce(-Vector3.forward * BackSpeed);
                CurrentGear = 0;
            }
        }
        else if (Input.GetKey(Front) && Input.GetKey(Back))
        {
            MoveSpeed = BrakeSpeed;
            BackSpeed = BrakeSpeed;
            CurrentGear = 0;
        }
        if(Input.GetKey(Brake))
        {
            MoveSpeed = BrakeSpeed;
            BackSpeed = BrakeSpeed;
        }

        /*Vector3 LocalVelocity = transform.InverseTransformDirection(PlayerRb.velocity);
        LocalVelocity.x = 0;
        PlayerRb.velocity = transform.TransformDirection(LocalVelocity);*/
    }
    void PlayerTurn()
    {
        if(!Input.GetKey(Back))
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
        else if(Input.GetKey(Back) && !Input.GetKey(Front))
        {
            if(Input.GetKey(Left))
            {
                PlayerRb.AddTorque(Vector3.up * TurnSpeed);
            }
            if(Input.GetKey(Right))
            {
                PlayerRb.AddTorque(-Vector3.up * TurnSpeed);
            }
        }
    }
    void GearSystem()
    {
        if(!Input.GetKey(Brake) && !Input.GetKey(Back))
        {
            if(SpeedCurrent < 1)
            {
                MoveSpeed = Gear1;
                CurrentGear = 0;
            }
            if(SpeedCurrent > 1 && SpeedCurrent < 80)
            {
                MoveSpeed = Gear1;
                CurrentGear = 1;
            }
            if(SpeedCurrent > 80 && SpeedCurrent < 110)
            {
                MoveSpeed = Gear2;
                CurrentGear = 2;
            }
            if(SpeedCurrent > 110 && SpeedCurrent < 150)
            {
                MoveSpeed = Gear3;
                CurrentGear = 3;
            }
            if(SpeedCurrent > 150 && SpeedCurrent < 190)
            {
                MoveSpeed = Gear4;
                CurrentGear = 4;
            }
            if(SpeedCurrent > 190)
            {
                MoveSpeed = Gear5;
                CurrentGear = 5;
            }

            BackSpeed = Gear0;
        }
    }
    void RotateCheck()
    {           
        if(transform.rotation.eulerAngles.z > 88 && transform.rotation.eulerAngles.z < 180 )
        {
           transform.rotation = Quaternion.Euler(0, 0, 0);    
        }
        if(transform.rotation.eulerAngles.z > 181 && transform.rotation.eulerAngles.z <= 272 )
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);   
        }
    }
    void LightsCheck()
    {
        if(Input.GetKeyDown(Lights))
        {
            if(!CarLights.activeSelf)
                CarLights.SetActive(true);
            else
                CarLights.SetActive(false);
        }
        
        if(Input.GetKey(Back) || Input.GetKey(Brake))
            Backlights.SetActive(true);
        else
            Backlights.SetActive(false);
    }
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Finish")
        {
            gameScr.FinishMap();
        }        
    }  
}
