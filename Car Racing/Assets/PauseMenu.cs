using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseObj;
    public bool PauseGame;

    public void PauseBtn()
    {
        PauseGame =! PauseGame;
        if(PauseGame)
        {
            PauseObj.SetActive(true);
        }
        else
        {
            PauseObj.SetActive(false);
        }
    }

}
