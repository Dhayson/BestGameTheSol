using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class SaveGame : MonoBehaviour
{
    [NonSerialized] public Data data;

    void Awake()
    {
        data = new Data();
    }

    public void Load()
    {
        string path = Path.GetFullPath("Data.json");

        if (!File.Exists(path))
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        else
        {
            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();
            data = JsonConvert.DeserializeObject<Data>(json);
            sr.Close();
        }
    }

    public void Save()
    {
        string path = Path.GetFullPath("Data.json");
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}

public class Data
{
    public (float x, float y, float z) playerPos;
}