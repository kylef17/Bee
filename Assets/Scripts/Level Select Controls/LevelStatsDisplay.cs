using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStatsDisplay : MonoBehaviour
{
    public string currentSelectedSceneName;
    public Text text;
    private LevelData currentSelectedLevelData;

    void Update()
    {
        bool hasVisitedLevel = SelectCurrentLevelData();
        if (hasVisitedLevel)
        {
            int numCollected = currentSelectedLevelData.totalNumCollectables - currentSelectedLevelData._idList.Count;

            text.text = currentSelectedSceneName + "\n" + "\n" + "Honey: " + numCollected.ToString() + "/" + currentSelectedLevelData.totalNumCollectables.ToString();
        } else
        {
            text.text = currentSelectedSceneName + "\n" + "\n" + "Honey: 0/??";
        }

    }

    private bool SelectCurrentLevelData()
    {
        foreach (LevelData levelData in PlayerProperties.levelDataList)
        {
            if (levelData._sceneName == currentSelectedSceneName)
            {
                currentSelectedLevelData = levelData;
                return true;
            }
        }
        return false;
    }
}
