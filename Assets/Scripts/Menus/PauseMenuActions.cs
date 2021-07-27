using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuActions : MonoBehaviour
{
    public PauseControl pauseControl;
    public void ReturnButton()
    {
        pauseControl.PauseGame();
    }

    public void SaveAndQuitButton()
    {
        SaveSystem.Save(PlayerProperties.currentSaveName);
        pauseControl.PauseGame();
        SceneManager.LoadScene("MainMenu");
    }
}
