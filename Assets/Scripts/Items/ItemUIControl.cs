using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIControl : MonoBehaviour
{
    [HideInInspector]
    public int itemNum;
    public string preNumText;
    public Text text;
    private int savedItemNum;

    void Update()
    {
        if (itemNum != savedItemNum)
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        text.text = preNumText + itemNum.ToString();
    }
}
