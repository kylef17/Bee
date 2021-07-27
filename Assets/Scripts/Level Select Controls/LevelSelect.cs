using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Levels levels;
    public MenuGamepadSupport menuGamepadSupport;
    public GameObject grid;
    public GameObject buttonPrefab;

    private int currentLevelIndex = 0;

    void Start()
    {
        if (!(grid.transform.childCount == levels.sceneList.Length))
        {
            AddButton();
        }
    }

    public void AddButton()
    {
        GameObject buttonObject = Instantiate(buttonPrefab, grid.transform);
        buttonObject.transform.GetChild(0).GetComponent<Text>().text = (currentLevelIndex+1).ToString();
        buttonObject.name = "Level" + currentLevelIndex+1 + "Button";
        int tempIndex = currentLevelIndex;
        buttonObject.GetComponent<Button>().onClick.AddListener(() => LoadLevel(levels.sceneList[tempIndex]));
        buttonObject.GetComponent<Button>().onClick.AddListener(() => SetCurrentLevelIndex(tempIndex));

        if (currentLevelIndex == 0)
        {
            menuGamepadSupport.SetObject(buttonObject);
        }

        if (!(grid.transform.childCount == levels.sceneList.Length))
        {
            currentLevelIndex++;
            AddButton();
        }
    }

    public void LoadLevel(string levelString)
    {
        SceneManager.LoadScene(levelString);
    }

    public void SetCurrentLevelIndex(int index)
    {
        CurrentLevel.currentLevelIndex = index;
    }
}
