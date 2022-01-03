using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseObj, StageUnlockObj;
    public GameScr gameScr;
    public bool PauseGame;
    public bool CanPause = true;
    public AllData allData;
    public SaveManagerScr saveManagerScr;
    public SoundsScr soundsScr;
    public GameObject MuteMusBtn, MuteEngBtn;
    
    void Update() 
    {
        MuteCheck();
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
                soundsScr.StartRace("Pause");
                soundsScr.Engine("Pause");
            }
            else
            {
                PauseObj.SetActive(false);
                Time.timeScale = 1;
                soundsScr.StartRace("UnPause");
                soundsScr.Engine("UnPause");
            }
        }
    }
    public void RestartBtn()
    {   
        PauseObj.SetActive(false);
        Time.timeScale = 1;
        PauseGame = false;
        soundsScr.Engine("UnPause");
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
        if(!allData.dataForSaving.StagesUnlocked)
        {
            allData.dataForSaving.StagesUnlocked = true;
            StageUnlockObj.SetActive(true);
            saveManagerScr.Save();
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
    
    void MuteCheck()
    {
        if(allData.MuteMus)
            MuteMusBtn.GetComponent<Image>().color = new Color32(255,255,255,100); 
        else
            MuteMusBtn.GetComponent<Image>().color = new Color32(255,255,255,255); 
         
        if(allData.MuteEng)
            MuteEngBtn.GetComponent<Image>().color = new Color32(255,255,255,100);   
        else
            MuteEngBtn.GetComponent<Image>().color = new Color32(255,255,255,255);    
    }

}
