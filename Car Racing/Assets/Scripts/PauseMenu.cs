using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseObj, ExitObj;
    public GameScr gameScr;
    public bool PauseGame;
    public AllData allData;

    public void PauseBtn()
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

}
