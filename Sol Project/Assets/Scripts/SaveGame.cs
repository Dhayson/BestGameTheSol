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
        if (TryLoad())
        {
            data.exists = true;
        }
    }

    bool TryLoad()
    {
        string path = Path.GetFullPath("Level0.Data.json");

        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();
            data = JsonConvert.DeserializeObject<Data>(json);
            sr.Close();
            return true;
        }
        else return false;
    }

    public void Save()
    {
        data.exists = true;
        string path = Path.GetFullPath("Level0.Data.json");
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    public void DeleteSave()
    {
        data.exists = false;
        string path = Path.GetFullPath("Level0.Data.json");
        File.Delete(path);
    }
}

public class Data
{
    public bool exists = false;

    /// <summary>
    /// Prefer to use PlayerPos property from other scripts
    /// </summary>
    public V3 playerPos;

    public struct V3
    {
        public float x, y, z;
    }

    [JsonIgnore]
    public Vector3 PlayerPos
    {
        get
        {
            if (exists)
            {
                return new Vector3(playerPos.x, playerPos.y, playerPos.z);
            }
            else throw new InexistentDataException();
        }
        set
        {
            (playerPos.x, playerPos.y, playerPos.z) = (value.x, value.y, value.z);
        }
    }
}

public class InexistentDataException : Exception { }