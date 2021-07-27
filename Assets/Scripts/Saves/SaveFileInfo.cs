using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Assets/Save File Info")]
public class SaveFileInfo : ScriptableObject
{
    public string fileName;
    public float timePlayed;
    public int honey;
    public int keys;
}
