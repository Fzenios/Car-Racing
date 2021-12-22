using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScr : MonoBehaviour
{
    public GameObject Player;
    public PlayerControls playerControls;
    public GameObject CountDown;
    public float TimerCurrent, TimerBest;
    public Vector3 Lvl1Loc, Lvl2Loc, Lvl3Loc, Lvl4Loc, Lvl5Loc;
    int CurrentLvl;    
    bool TimerStart;
    public TMP_Text TimerTxt;
    public float[] HighScores;
    public bool[] LevelsBl;
    public Animator animator;
    public GameObject HighScoreObj;
    public GameObject FinishBtn;

     
    void Start()
    { 
        for (int i = 1; i < LevelsBl.Length; i++)
        {
            LevelsBl[i] = false;            
        }        
        LevelsBl[0] = true;
        
        TimerTxt.text = "";
        StartMap();
    }

    void Update()
    {
        if(TimerStart)
        {
            DisplayTime();
        }
    }
    public void StartMap()
    {
        playerControls.CanMove = false;
        TimerStart = false;
        TimerCurrent = 0.0f;
        animator.SetBool("Finish", false);
        CountDown.SetActive(true);
        HighScoreObj.SetActive(false);
        StartCoroutine(WaitForTheLights());
        for (int i = 0; i < LevelsBl.Length; i++)
        {
            if(LevelsBl[i])
                CurrentLvl = i + 1;                        
        }
        
    }
    void DisplayTime()
    {
        TimerCurrent += Time.deltaTime;
        int Minutes = Mathf.FloorToInt(TimerCurrent / 60.0f);
        int Seconds = Mathf.FloorToInt(TimerCurrent - Minutes * 60);
        int Milliseconds = Mathf.FloorToInt((TimerCurrent * 100f) % 100f);
        TimerTxt.text = string.Format("{0:0}:{1:00}:{2:00}", Minutes, Seconds, Milliseconds);
    }
    public void FinishMap()
    {
        playerControls.CanMove = false;
        TimerStart = false;
        animator.SetBool("Finish", true);
        for (int i = 0; i < LevelsBl.Length; i++)
        {
            if(LevelsBl[i])
                CurrentLvl = i;                        
        }
        if(TimerCurrent > HighScores[CurrentLvl])
        {
            HighScores[CurrentLvl] = TimerCurrent;
            HighScoreObj.SetActive(true);
        }      
        FinishBtn.SetActive(true);
    }

    IEnumerator WaitForTheLights()
    {
        yield return new WaitForSeconds(4);
        playerControls.CanMove = true;
        TimerStart = true;
        yield return new WaitForSeconds(2);
        CountDown.SetActive(false);
    }  
    public void LoadNextMap()
    {

    }    
}
