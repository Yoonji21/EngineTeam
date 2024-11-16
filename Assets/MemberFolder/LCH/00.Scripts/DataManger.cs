using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManger : MonoBehaviour
{
    public static DataManger Intance;

    public StageData stageData;
    private void Awake()
    {
        if(Intance == null)
        {
            Intance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        stageData = new StageData();

        LoadData();
    }


    [SerializeField] private StageDataSO _dataSO;

    public void SaveData()
    {
        OverwritingData(false);

        SaveManager.Save(stageData,"StageJson");

        LoadData();
    }


    public void LoadData()
    {
        SaveManager.Load<StageData>("StageJson");
        OverwritingData(true);
    }

    private void OverwritingData(bool isLoad)
    {
        if (isLoad)
        {
            _dataSO.StageClear = stageData.StageLavelNum;
        }
        else
        {
            stageData.StageLavelNum = _dataSO.StageClear;
        }
    }
}

public class StageData
{
    public int StageLavelNum = 0;
}

