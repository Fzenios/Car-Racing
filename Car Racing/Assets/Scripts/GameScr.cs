using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScr : MonoBehaviour
{
    public GameObject Player;
    public Transform playertra;
    public PlayerControls playerControls;
    public GameObject CountDown;
    public float TimerCurrent, TimerBest;
    int CurrentLvl;    
    bool TimerStart;
    public TMP_Text TimerTxt;
    public Animator animator;
    public GameObject HighScoreObj;
    public GameObject FinishBtn;
    public GameObject[] LevelObj;
    public Vector3[] LvlLoc;
    public Quaternion[] RotationLoc;
    public float[] HighScores;
    public bool[] LevelsBl;

     
    void Start()
    { 
        for (int i = 1; i < LevelsBl.Length; i++)
        {
            LevelsBl[i] = false;            
        }        
        Player.transform.rotation = Quaternion.Euler(RotationLoc[0].x, RotationLoc[0].y, RotationLoc[0].z);
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
        SetLocation();
        StartCoroutine(WaitForTheLights()); 
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

    public void LoadNextMap()
    {
        for (int i = 0; i < LevelsBl.Length; i++)
        {
            if(LevelsBl[i])
                CurrentLvl = i;                        
        }
        Player.transform.rotation = Quaternion.Euler(RotationLoc[CurrentLvl + 1].x, RotationLoc[CurrentLvl + 1].y, RotationLoc[CurrentLvl + 1].z);
        LevelsBl[CurrentLvl] = false;
        LevelsBl[CurrentLvl + 1] = true;
        LevelObj[CurrentLvl].SetActive(false);
        LevelObj[CurrentLvl + 1].SetActive(true);

        FinishBtn.SetActive(false);

        StartCoroutine(WaitForNextMap());
    }  
    void SetLocation()
    {
        for (int i = 0; i < LevelsBl.Length; i++)
        {
            if(LevelsBl[i])
            {
                Player.transform.position = new Vector3(LvlLoc[i].x, LvlLoc[i].y, LvlLoc[i].z);  
            }                     
        }
    } 

    IEnumerator WaitForTheLights()
    {
        yield return new WaitForSeconds(4);
        playerControls.CanMove = true;
        TimerStart = true;
        yield return new WaitForSeconds(2);
        CountDown.SetActive(false);
    }  
    IEnumerator WaitForNextMap()
    {
        TimerStart = false;
        TimerCurrent = 0.0f;
        animator.SetBool("Finish", false);
        TimerTxt.text = "";
        HighScoreObj.SetActive(false);
        yield return new WaitForSeconds(10);
        SetLocation();
        CountDown.SetActive(true);
        StartCoroutine(WaitForTheLights()); 
        
    }

     
}
