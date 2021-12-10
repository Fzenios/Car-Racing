using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScr : MonoBehaviour
{
    public GameObject Player;
    public PlayerControls playerControls;
    public GameObject CountDown;

     
    void Start()
    {
        playerControls.CanMove = false;
    }

    void Update()
    {
        
    }
    public void StartMap()
    {
        playerControls.CanMove = false;
        StartCoroutine(WaitForTheLights());
    }
    IEnumerator WaitForTheLights()
    {
        yield return new WaitForSeconds(4);
        playerControls.CanMove = true;
        yield return new WaitForSeconds(2);
        CountDown.SetActive(false);
    }
    
}
