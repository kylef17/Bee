using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelButtonInfo : MonoBehaviour, ISelectHandler
{
    public string sceneName;
    public LevelStatsDisplay levelStatDisplay;

    public void OnSelect(BaseEventData eventData)
    {
        levelStatDisplay.currentSelectedSceneName = sceneName;
    }
}
