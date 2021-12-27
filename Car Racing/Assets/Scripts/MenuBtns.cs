using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuBtns : MonoBehaviour
{
    public AllData allData;
    public TMP_Text[] LevelTxt;
    
    void Update() 
    {
        for (int i = 0; i < LevelTxt.Length; i++)
        {
            LevelTxt[i].text = TimeCalc(allData.HighScores[i]);
        }
    }    
    string TimeCalc(float HighScore)
    {
        int Minutes = Mathf.FloorToInt(HighScore / 60.0f);
        int Seconds = Mathf.FloorToInt(HighScore - Minutes * 60);
        int Milliseconds = Mathf.FloorToInt((HighScore * 100f) % 100f);
        return string.Format("{0:0}:{1:00}:{2:00}", Minutes, Seconds, Milliseconds);;
    }
    public void StartBtn()
    {
        allData.CurrentLevel = 0;
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        allData.CurrentLevel = 1;
        SceneManager.LoadScene(1);
    }
    public void Level3()
    {
        allData.CurrentLevel = 2;
        SceneManager.LoadScene(1);
    }
    public void Level4()
    {
        allData.CurrentLevel = 3;
        SceneManager.LoadScene(1);
    }
    public void Level5()
    {
        allData.CurrentLevel = 4;
        SceneManager.LoadScene(1);
    }

}
