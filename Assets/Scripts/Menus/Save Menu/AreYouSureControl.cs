using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreYouSureControl : MonoBehaviour
{
    public string fileName;
    public Text titleText;
    public SelectSaveActions selectSaveActions;

    void Update()
    {
        titleText.text = "Are you sure you want to delete " + fileName + "?" + "\n" + "This cannot be undone.";
    }

    public void ConfirmDelete()
    {
        SaveSystem.DeleteSave(fileName);
        selectSaveActions.CloseConfirmationPanel();
    }

    public void Cancel()
    {
        selectSaveActions.CloseConfirmationPanel();
    }
}
