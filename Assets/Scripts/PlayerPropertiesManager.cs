using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPropertiesManager : MonoBehaviour
{
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
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        GenerateUI();
        ResetPlayerProperites();
        SaveOnSceneLoad();
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
            PlayerProperties.levelDataList = new List<LevelData>();
        }
    }

    private void SaveOnSceneLoad()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            SaveSystem.Save(PlayerProperties.currentSaveName);
        }
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
