using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPickup : MonoBehaviour
{
    public LevelDataListManager levelDataListManager;
    public int itemTypeIDNum;
    public void DestroyItem()
    {
        levelDataListManager.OnItemPickup(itemTypeIDNum, gameObject);
        Destroy(gameObject);
    }
}
