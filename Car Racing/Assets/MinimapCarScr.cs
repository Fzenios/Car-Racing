using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCarScr : MonoBehaviour
{
    public Transform Player;
    void Start()
    {
        
    }

    void Update()
    {
        
        transform.rotation = Quaternion.Euler(0,0,-Player.eulerAngles.y+90);
    }
}
