using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDataListManager : MonoBehaviour
{
    public List<string> itemTags;
    public Dictionary<int, GameObject> honeyDict;
    public Dictionary<int, GameObject> keyDict;

    public bool hasGeneratedItemDictionaries;
    private Level currentLevel;

    void Update()
    {
    }

    public void GenerateItemDictionarys()
    {
        Debug.Log(honeyDict);
        Debug.Log("Generating Dictionaries");
        honeyDict = new Dictionary<int, GameObject>();
        int i = 0;
        foreach (GameObject honeyObject in GameObject.FindGameObjectsWithTag(itemTags[0]))
        {
            honeyDict.Add(i, honeyObject);
            i++;
        }

        keyDict = new Dictionary<int, GameObject>();
        int j = 0;
        foreach (GameObject keyObject in GameObject.FindGameObjectsWithTag(itemTags[1]))
        {
            keyDict.Add(j, keyObject);
            j++;
        }
        if (honeyDict == null)
        {
            Debug.Log("honeyDict null in GenerateItemDictionaries");
        }
        hasGeneratedItemDictionaries = true;
    }

    public void GenerateLevel()
    {
        // Check if scene name (level name) exists in playerproperties.levelDataList
        bool levelAlreadyLoaded = false;
        if (PlayerProperties.levelDataList != null)
        {
            foreach (Level level in PlayerProperties.levelDataList)
            {
                if (level.name.Equals(SceneManager.GetActiveScene().name))
                {
                    levelAlreadyLoaded = true;
                }
            }
        } else
        {
            Debug.LogError("PlayerProperites.levelDataList == null");
        }


        // If level does not already exist, create and add to list
        if (!levelAlreadyLoaded)
        {
            // Get a list of the keys in the dict for each item
            List<int> honeyIDList = new List<int>(honeyDict.Keys);
            List<int> keysIDList = new List<int>(keyDict.Keys);

            Level level = new Level(SceneManager.GetActiveScene().name, honeyIDList, keysIDList, true);
            PlayerProperties.levelDataList.Add(level);
            currentLevel = level;
        } 
        else // Level exists, get rid of unneccessary game objects
        {

            // Find the data class for the current level
            foreach (Level level in PlayerProperties.levelDataList)
            {
                if (level.name.Equals(SceneManager.GetActiveScene().name))
                {
                    currentLevel = level;
                    RemoveItems(level.honeyArray, honeyDict);
                    RemoveItems(level.keyArray, keyDict);
                }
            }

        }
    }

    private void RemoveItems(List<int> idList, Dictionary<int, GameObject> itemDict)
    {
        // Loop through all the item ids from the level data
        foreach (int i in idList)
        {
            // If the item id is not in the list
            if (!itemDict.ContainsKey(i))
            {
                // Remove the cooresponding item from the level
                Destroy(itemDict[i]);
                itemDict.Remove(i);
            }
        }
    }

    public void OnItemPickup(int itemTypeIDNum, GameObject item)
    {
        if (honeyDict == null)
        {
            Debug.Log("honeyDict null outside switch");
        }
        GenerateItemDictionarys();

        switch (itemTypeIDNum) 
        {
            case 0:
                if (!hasGeneratedItemDictionaries)
                {
                    Debug.Log("hasn't generated the dicitonaries dingus");
                }
                if (honeyDict == null)
                {
                    Debug.Log("honeyDict null in switch");
                }
                int honeyKey = FindGameObjectKey(item, honeyDict);
                honeyDict.Remove(honeyKey);
                currentLevel.honeyArray.Remove(honeyKey);
                break;
            case 1:
                int keyKey = FindGameObjectKey(item, keyDict);
                keyDict.Remove(keyKey);
                currentLevel.keyArray.Remove(keyKey);
                break;
        }

    }

    private int FindGameObjectKey(GameObject gameObject, Dictionary<int, GameObject> dict)
    {
        foreach (KeyValuePair<int, GameObject> entry in dict)
        {
            if (entry.Value.Equals(gameObject))
            {
                return entry.Key;
            }
        }

        return -1;
    }
}
