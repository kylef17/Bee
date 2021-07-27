using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenActions : MonoBehaviour
{
    public Levels levels;
    public MenuClose menuClose;
    public string hubSceneName;
    private Respawn respawn;

    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("RespawnPoint").GetComponent<Respawn>();
    }

    public void NextLevelButton()
    {
        CurrentLevel.currentLevelIndex += 1;
        Debug.Log(CurrentLevel.currentLevelIndex);
        SceneManager.LoadScene(levels.sceneList[CurrentLevel.currentLevelIndex]);
    }

    public void BackToHubButton()
    {
        SceneManager.LoadScene(hubSceneName);
    }

    public void RetryButton()
    {
        respawn.TriggerRespawn();
        menuClose.CloseInteraction();
    }
}
