using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManagerScr : MonoBehaviour
{
    public AllData allData;
    public void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/TestSavee.dat", FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();
                
        formatter.Serialize (file, allData.dataForSaving);
        
        Debug.Log("egine to save");

        file.Close();
    }

    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/TestSavee.dat", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();

        allData.dataForSaving = (AllData.DataForSaving)formatter.Deserialize(file);
        
        Debug.Log("egine to load");

        file.Close();
    }
}
