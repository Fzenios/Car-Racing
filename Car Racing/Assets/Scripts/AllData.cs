using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllData", menuName ="AllData")]
public class AllData : ScriptableObject
{
    public int CurrentLevel;
    public DataForSaving dataForSaving;
    public bool Mute;
    
    [System.Serializable]
    public class DataForSaving
    {
        public float[] HighScores;
        public bool StagesUnlocked;
    }
}
