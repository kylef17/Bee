using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public PlayerStateController playerStateController;
    public GameObject pausePanel;
    private GameObject panelObject;
    public bool isPaused;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            panelObject = Instantiate(pausePanel, GameObject.FindGameObjectWithTag("Canvas").transform);
            panelObject.GetComponent<PauseMenuActions>().pauseControl = this;
            playerStateController.SetState(PlayerStateController.States.noMovement);
        } else
        {
            isPaused = false;
            Time.timeScale = 1;
            Destroy(panelObject);
            playerStateController.SetState(PlayerStateController.States.freeMovement);
        }
    }

}
