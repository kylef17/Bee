using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectSaveActions : MonoBehaviour
{
    public SaveFileInfo[] saveFileInfoArray;
    public Button[] saveButtons;
    public Button[] deleteButtons;
    public GameObject mainMenuPanel;
    public GameObject areYouSurePanel;
    public GameObject saveButtonsObject;

    void Start()
    {
        for (int i = 0; i < saveButtons.Length; i++)
        {
            int tempIndex = i;
            AddSaveButtonAction(saveFileInfoArray[tempIndex], saveButtons[tempIndex], deleteButtons[tempIndex]);
        }
    }

    public void AddSaveButtonAction(SaveFileInfo saveFileInfo, Button saveButton, Button deleteButton)
    {
        saveButton.onClick.AddListener(() => LoadSave(saveFileInfo.fileName));
        deleteButton.onClick.AddListener(() => DeleteSave(saveFileInfo.fileName));
    }

    public void LoadSave(string saveFileName)
    {
        SaveSystem.LoadData(saveFileName);
        PlayerProperties.currentSaveName = saveFileName;
        SceneManager.LoadScene(PlayerProperties.currentScene);
    }

    public void DeleteSave(string saveFileName)
    {
        OpenConfirmationPanel();
        areYouSurePanel.GetComponent<AreYouSureControl>().fileName = saveFileName;
    }

    public void BackButton()
    {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void OpenConfirmationPanel()
    {
        areYouSurePanel.SetActive(true);
        saveButtonsObject.SetActive(false);
    }

    public void CloseConfirmationPanel()
    {
        areYouSurePanel.SetActive(false);
        saveButtonsObject.SetActive(true);
    }
}
