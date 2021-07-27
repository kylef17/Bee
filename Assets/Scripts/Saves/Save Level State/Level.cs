using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string name;
    public List<int> honeyArray;
    public List<int> keyArray;
    public bool hasBeenVisited;
    public bool hasBeenCompleted;

    public Level(string name, List<int> honeyArray, List<int> keyArray, bool hasBeenVisited)
    {
        this.name = name;
        this.honeyArray = honeyArray;
        this.keyArray = keyArray;
        this.hasBeenVisited = hasBeenVisited;
    }

    public void setVisited(bool boolean)
    {
        hasBeenVisited = boolean;
    }

    public void setCompleted(bool boolean)
    {
        hasBeenCompleted = boolean;
    }

    public bool compareItems(List<int> itemList, int itemID)
    {
        return itemList.Contains(itemID);
    }

    public bool removeItem(List<int> itemList, int itemID)
    {
        return itemList.Remove(itemID);
    }
}
