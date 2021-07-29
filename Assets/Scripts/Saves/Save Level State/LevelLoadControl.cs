using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadControl : MonoBehaviour
{
    private List<GameObject> honeyObjects;
    private List<ItemID> honeyIDs;

    private static LevelLoadControl _instance;
    public static LevelLoadControl Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += LoadLevel;
    }

    private void LoadLevel(Scene scene, LoadSceneMode mode)
    {
        // make a list of itemObjects in the scene
        // set the ItemId's of the itemObjects
        //
        // if PlayerProperties.currentScene levelData exists in PlayerProperties
        //      loop through the levelData item ids
        //      if an id exists in the itemObjects list but not the levelData list 
        //          destroy the itemObject
        // else 
        //      create a new levelData using the itemObjects id list
        //      add to PlayerProperties



        // create the itemIDs list

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {


            honeyObjects = createGameObjectList("Honey");
            honeyIDs = createItemIdList(honeyObjects);

            LevelData currentLevelData = checkIfLevelDataExists();

            if (currentLevelData != null)
            {
                DestroyItems(honeyIDs, currentLevelData);
            }
            else
            {
                CreateNewLevelData(honeyIDs);
            }


        }
    }

    private void CreateNewLevelData(List<ItemID> itemIdList)
    {
        List<int> itemIdIntList = new List<int>();
        foreach (ItemID itemId in itemIdList)
        {
            itemIdIntList.Add(itemId.itemId);
        }

        LevelData newLevelData = new LevelData(SceneManager.GetActiveScene().name, itemIdIntList);
        PlayerProperties.levelDataList.Add(newLevelData);
    }

    private void DestroyItems(List<ItemID> itemIdList, LevelData currentLevelData)
    {
        foreach (ItemID itemId in itemIdList)
        {
            if (!currentLevelData._idList.Contains(itemId.itemId))
            {
                Destroy(itemId.gameObject);
            }
        }
    }

    private List<GameObject> createGameObjectList(string itemTag)
    {
        List<GameObject> itemObjectList = new List<GameObject>(GameObject.FindGameObjectsWithTag(itemTag));
        return itemObjectList;
    }

    private List<ItemID> createItemIdList(List<GameObject> itemObjectList)
    {
        List<ItemID> itemIdList = new List<ItemID>();
        int i = 0;
        foreach (GameObject itemObject in itemObjectList)
        {
            ItemID itemId = itemObject.GetComponent<ItemID>();
            itemId.itemId = i;
            itemIdList.Add(itemId);
            i++;
        }

        return itemIdList;
    }

    private LevelData checkIfLevelDataExists()
    {
        foreach (LevelData levelData in PlayerProperties.levelDataList)
        {
            if (levelData._sceneName == SceneManager.GetActiveScene().name)
            {
                return levelData;
            }
        }

        return null;
    }
}
