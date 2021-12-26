using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllData", menuName ="AllData")]
public class AllData : ScriptableObject
{
    public bool StagesUnlocked = false;
    public float[] HighScores;

}
