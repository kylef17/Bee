using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(string saveName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, saveName + ".save");

        FileStream file = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(file, data);

        file.Close();
    }

    public static void DeleteSave(string saveName)
    {
        string path = Path.Combine(Application.persistentDataPath, saveName + ".save");
        File.Delete(path);
    }

    public static bool FindSave(string saveName)
    {
        string path = Path.Combine(Application.persistentDataPath, saveName + ".save");
        return File.Exists(path);
    }

    public static SaveData Load(string path)
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(file) as SaveData;

            file.Close();

            return data;
        } 
        else
        {
            Debug.LogErrorFormat("Save file not found at {0}", path);
            return null;
        }
    }

    public static SaveData ReturnSaveData(string fileName)
    {
        SaveData data = Load(Path.Combine(Application.persistentDataPath, fileName + ".save"));
        return data;
    }

    public static void LoadData(string fileName)
    {
        SaveData data = Load(Path.Combine(Application.persistentDataPath, fileName + ".save"));

        if (data != null)
        {
            data.ApplyData();
        }
    }
}
