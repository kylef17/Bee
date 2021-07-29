using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public int honey;
    public int keys;
    public string currentScene;
    public List<LevelData> levelDataList;


    public SaveData()
    {
        honey = PlayerProperties.honey;
        keys = PlayerProperties.keys;
        currentScene = PlayerProperties.currentScene;
        levelDataList = PlayerProperties.levelDataList;
    }

    public void ApplyData()
    {
        PlayerProperties.honey = honey;
        PlayerProperties.keys = keys;
        PlayerProperties.currentScene = currentScene;
        PlayerProperties.levelDataList = levelDataList;
    }
}
