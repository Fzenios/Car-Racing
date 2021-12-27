using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseObj, StageUnlockObj;
    public GameScr gameScr;
    public bool PauseGame;
    public bool CanPause = true;
    public AllData allData;
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))   
        {
            
            PauseBtn();
        } 
    }
    public void PauseBtn()
    {
        if(CanPause)
        {
            PauseGame =! PauseGame;
            if(PauseGame)
            {
                PauseObj.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                PauseObj.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void RestartBtn()
    {   
        PauseObj.SetActive(false);
        Time.timeScale = 1;
        PauseGame = false;
        gameScr.RestartMap();
    }
    public void ExitBtn()
    {
        Time.timeScale = 1;
        PauseGame = false;
        SceneManager.LoadScene(0);
    }
    public void ExitEndGameBtn()
    {
        if(!allData.StagesUnlocked)
        {
            allData.StagesUnlocked = true;
            StageUnlockObj.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseGame = false;
            SceneManager.LoadScene(0);
        }
    }
    public void CanPauseBool()
    {
        CanPause =! CanPause;
    }

}
