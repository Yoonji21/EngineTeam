using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    private static readonly string JsonPath = Application.dataPath + "/Json/";
    public static void Save<T>(T obj, string jsonFileName)
    {
        //if (!Directory.Exists(LocalPath))
        //{

        //}
        string path = JsonPath + jsonFileName + ".json";
        string json = JsonUtility.ToJson(obj);
        File.WriteAllText(path,json);
    }

    public static T Load<T>(string jsonFileName)
    {
        string path = JsonPath + jsonFileName + ".json";
        string L = File.ReadAllText(JsonPath);
       T OBJ = JsonUtility.FromJson<T>(L);
        return OBJ;
    }
}
