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
    public float TimerCurrent;
    int CurrentLvl;    
    bool TimerStart;
    public TMP_Text TimerTxt;
    public Animator animator;
    public GameObject HighScoreObj;
    public GameObject FinishBtn, EndGameFinishBtn, PauseBtn;
    public GameObject[] LevelObj;
    public Vector3[] LvlLoc;
    public Quaternion[] RotationLoc;
    public float[] HighScores;
    public bool[] LevelsBl;
    Coroutine WaitforTheLights;
    public AllData allData;

    void Start() 
    {
        for (int i = 0; i < allData.HighScores.Length; i++)
        {
            HighScores[i] = allData.HighScores[i];            
        }  
        PrestartGame();        
    }
    void Update()
    {
        if(TimerStart)
        {
            DisplayTime();
        }
    }
    public void PrestartGame()
    {
        for (int i = 0; i < LevelsBl.Length; i++)
        {
            LevelsBl[i] = false;            
        }   
        
        int CurrentLevel = allData.CurrentLevel;
        LevelsBl[CurrentLevel] = true;   
        Player.transform.rotation = Quaternion.Euler(RotationLoc[CurrentLevel].x, RotationLoc[CurrentLevel].y, RotationLoc[CurrentLevel].z);
        
        StartMap();
        LoadFirstMap();
    }
    public void StartMap()
    {
        PauseBtn.SetActive(true);
        playerControls.CanMove = false;
        playerControls.CurrentGear = 0;
        TimerStart = false;
        TimerCurrent = 0.0f;
        animator.SetBool("Finish", false);
        CountDown.SetActive(true);
        HighScoreObj.SetActive(false);
        FinishBtn.SetActive(false);
        TimerTxt.text = "";
        SetLocation();
        WaitforTheLights = StartCoroutine(WaitForTheLights()); 

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
        playerControls.CurrentGear = 0;
        TimerStart = false;
        animator.SetBool("Finish", true);
        for (int i = 0; i < LevelsBl.Length; i++)
        {
            if(LevelsBl[i])
                CurrentLvl = i;                        
        }
        if(HighScores[CurrentLvl] == 0)
            {
                HighScores[CurrentLvl] = TimerCurrent;
                allData.HighScores[CurrentLvl] = HighScores[CurrentLvl];
                HighScoreObj.SetActive(true);
            }
        else if(TimerCurrent < HighScores[CurrentLvl])
            {
                HighScores[CurrentLvl] = TimerCurrent;
                allData.HighScores[CurrentLvl] = HighScores[CurrentLvl];
                HighScoreObj.SetActive(true);
            }      
        if(CurrentLvl != 4)
            FinishBtn.SetActive(true);
        else
        {
            EndGameFinishBtn.SetActive(true);
        }
        PauseBtn.SetActive(false);
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

        StartMap();
    }  
    void LoadFirstMap()
    {
        for (int i = 0; i < LevelsBl.Length; i++)
        {
            LevelObj[i].SetActive(false);                      
        }
        LevelObj[allData.CurrentLevel].SetActive(true);
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
    
    public void RestartMap()
    {
        for (int i = 0; i < LevelsBl.Length; i++)
        {
            if(LevelsBl[i])
                CurrentLvl = i;                        
        }
        Player.transform.rotation = Quaternion.Euler(RotationLoc[CurrentLvl].x, RotationLoc[CurrentLvl].y, RotationLoc[CurrentLvl].z);
        if(CountDown.activeSelf)
            CountDown.SetActive(false);
        
        StopCoroutine(WaitforTheLights);
        StartMap();
    }

    IEnumerator WaitForTheLights()
    {
        yield return new WaitForSeconds(4);
        playerControls.CanMove = true;
        TimerStart = true;
        yield return new WaitForSeconds(2);
        CountDown.SetActive(false);
    }  
}
