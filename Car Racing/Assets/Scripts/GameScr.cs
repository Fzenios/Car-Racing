using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScr : MonoBehaviour
{
    public GameObject Player;
    public PlayerControls playerControls;
    public GameObject CountDown;
    public float TimerCurrent, TimerBest;
    public Vector3 Lvl1Loc, Lvl2Loc, Lvl3Loc, Lvl4Loc, Lvl5Loc;
    bool TimerStart;
    public Text TimerTxt;

     
    void Start()
    {
        playerControls.CanMove = false;
        TimerStart = false;
        TimerCurrent = 0;
    }

    void Update()
    {
        if(!TimerStart)
        {
            TimerCurrent += Time.deltaTime;
            TimerTxt.text = "Time :" + TimerCurrent.ToString("0:00");
        }
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
        TimerStart = true;
    }
    
}
