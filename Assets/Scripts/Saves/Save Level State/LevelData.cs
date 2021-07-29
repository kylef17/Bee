using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    // To be included inside List in PlayerProperties (and SaveData)
    // Compare to list of itemID's in LevelLoadControl

    public string _sceneName;
    public List<int> _idList;
    public int totalNumCollectables;

    public LevelData(string sceneName, List<int> idList)
    {
        _sceneName = sceneName;
        _idList = idList;
        totalNumCollectables = _idList.Count;
    }
}
