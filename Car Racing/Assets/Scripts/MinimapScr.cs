using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScr : MonoBehaviour
{
    public Transform Player;
    
    void LateUpdate() 
    { 
        transform.position = new Vector3(Player.position.x, Player.position.y + 200, Player.position.z);
    }
}
