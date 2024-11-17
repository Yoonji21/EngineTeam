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
        stageData = SaveManager.Load<StageData>("StageJson");
        if (stageData == null)
        {
            stageData = new StageData();
            SaveData();
            Debug.Log("새로운 세이브 파일을 생성했습니다.");
        }
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

