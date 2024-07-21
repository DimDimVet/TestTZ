using UnityEngine;

[CreateAssetMenu(fileName = "DropInvertorySettings", menuName = "ScriptableObjects/DropInvertorySettings")]
public class DropInvertorySettings : ScriptableObject
{
    [Header("Описание")]
    [TextArea(2, 8)]
    public string Manual = $"nullManual";

}
