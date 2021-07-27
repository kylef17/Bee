using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Assets/Interactable/Menu On Interact")]
public class MenuOnInteract : Interactable
{
    public GameObject panel;

    public override void Interact()
    {
        GameObject panelObject = Instantiate(panel, GameObject.FindGameObjectWithTag("Canvas").transform);
        panelObject.SetActive(true);
    }
}
