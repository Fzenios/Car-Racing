using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuBtns : MonoBehaviour
{
    public AllData allData;
    public TMP_Text[] LevelTxt;
    public GameObject FinishGameTxt;
    public GameObject StageSelectOBj;
    public SaveManagerScr saveManagerScr;
    
    void Awake() 
    {
        allData.dataForSaving.StagesUnlocked = false; 
        saveManagerScr.Load();        
    }
   
    void Start() 
    {
        if(!allData.dataForSaving.StagesUnlocked)
        {
            FinishGameTxt.SetActive(true);
            StageSelectOBj.GetComponent<Image>().color = new Color32(36,36,36,255);   
            StageSelectOBj.GetComponent<Button>().interactable = false;         
        }
        else
        {
            FinishGameTxt.SetActive(false);
            StageSelectOBj.GetComponent<Image>().color = Color.white;
            StageSelectOBj.GetComponent<Button>().interactable = true;  
        }
    }
    void Update() 
    {
        for (int i = 0; i < LevelTxt.Length; i++)
        {
            LevelTxt[i].text = TimeCalc(allData.dataForSaving.HighScores[i]);
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
