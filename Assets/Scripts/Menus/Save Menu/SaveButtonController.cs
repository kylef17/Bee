using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButtonController : MonoBehaviour
{
    public SaveFileInfo saveFileInfo;
    public GameObject deleteButton;
    public Text buttonText;

    void Update()
    {
        if (SaveSystem.FindSave(saveFileInfo.fileName))
        {
            deleteButton.SetActive(true);
            SaveData data = SaveSystem.ReturnSaveData(saveFileInfo.fileName);
            buttonText.text = saveFileInfo.fileName + "\n" + "\n" + "Current level: " + data.currentScene + "\n" + "Honey: " + data.honey.ToString()
                + "\n" + "Keys: " + data.keys.ToString();
        } else
        {
            deleteButton.SetActive(false);
            buttonText.text = "New Game";
        }
    }
}
