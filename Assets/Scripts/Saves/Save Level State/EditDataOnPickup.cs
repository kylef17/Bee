using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditDataOnPickup : MonoBehaviour
{
    public ItemID itemId;

    public void EditData()
    {
        foreach (LevelData levelData in PlayerProperties.levelDataList)
        {
            if (levelData._sceneName == PlayerProperties.currentScene)
            {
                levelData._idList.Remove(itemId.itemId);
            }
        }
    }
}
