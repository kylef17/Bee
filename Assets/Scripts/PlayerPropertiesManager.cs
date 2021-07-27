using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPropertiesManager : MonoBehaviour
{
    public LevelDataListManager levelDataListManager;
    public StaticUIElements uiElements;
    public string defaultSceneName;
    public GameObject[] createdElements;

    private static PlayerPropertiesManager _instance;
    public static PlayerPropertiesManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoad;
        SceneManager.sceneLoaded += GenerateLevelInfo;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        levelDataListManager.hasGeneratedItemDictionaries = false;
        GenerateUI();
        ResetPlayerProperites();
        SaveOnSceneLoad();
    }

    private void GenerateLevelInfo(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            levelDataListManager.GenerateItemDictionarys();
            levelDataListManager.GenerateLevel();
        }
    }

    private void GenerateUI()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            createdElements = new GameObject[uiElements.uiElements.Length];
            int i = 0;
            foreach (GameObject uiElement in uiElements.uiElements)
            {
                createdElements[i] = Instantiate(uiElement, GameObject.FindGameObjectWithTag("Canvas").transform) as GameObject;
                i++;
            }
        }
    }

    private void ResetPlayerProperites()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerProperties.currentScene = defaultSceneName;
            PlayerProperties.honey = 0;
            PlayerProperties.keys = 0;
            PlayerProperties.numLevelsCompleted = 0;
            PlayerProperties.levelDataList = new List<Level>();
        }
    }

    private void SaveOnSceneLoad()
    {
        SaveSystem.Save(PlayerProperties.currentSaveName);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            PlayerProperties.currentScene = SceneManager.GetActiveScene().name;
        }

        if (createdElements.Length > 0)
        {
            if (createdElements[0] != null)
            {
                createdElements[0].GetComponent<ItemUIControl>().itemNum = PlayerProperties.honey;
            }

            if (createdElements[1] != null)
            {
                createdElements[1].GetComponent<ItemUIControl>().itemNum = PlayerProperties.keys;
            }
        }
    }
}
