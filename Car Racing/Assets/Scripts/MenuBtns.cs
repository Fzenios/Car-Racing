using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuBtns : MonoBehaviour
{
    public AllData allData;
    public TMP_Text Level1, Level2, Level3, Level4, Level5;
    
    void Update() 
    {
        Level1.text = allData.HighScores[0].ToString();        
    }
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }

}
