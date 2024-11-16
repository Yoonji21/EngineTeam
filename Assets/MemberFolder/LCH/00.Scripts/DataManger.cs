using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{

    public StageData stageData;

    public void SaveData()
    {
        SaveManager.Save(stageData,"StageJson");
    }

    public void LoadData()
    {
        SaveManager.Load<StageData>("StageJson");
    }
}

public class StageData
{
    public int StageLavelNum = 0;
}

