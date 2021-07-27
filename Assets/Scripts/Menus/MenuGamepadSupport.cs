using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuGamepadSupport : MonoBehaviour
{
    public GameObject firstButtonSelected;

    void Awake()
    {
        if (firstButtonSelected != null)
        {
            SetObject(firstButtonSelected);
        }
    }

    void OnDestroy()
    {
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    void OnEnable()
    {
        if (firstButtonSelected != null)
        {
            SetObject(firstButtonSelected);
        }
    }

    public void SetObject(GameObject selectedObject)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(selectedObject);
        selectedObject.GetComponent<Button>().OnSelect(null);
    }
}
