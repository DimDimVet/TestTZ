using UnityEngine;

[CreateAssetMenu(fileName = "RotatseSetting", menuName = "ScriptableObjects/RotatseSetting")]
public class RotatseSetting : ScriptableObject
{
    [Header("Диапозон угла+"), Range(0, 90)]
    public float AnglePlus = 75f;
    [Header("Диапозон угла-"), Range(-90, 0)]
    public float AngleMinus = -75f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
