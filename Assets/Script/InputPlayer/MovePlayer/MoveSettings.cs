using UnityEngine;

[CreateAssetMenu(fileName = "MoveSettings", menuName = "ScriptableObjects/MoveSettings")]
public class MoveSettings : ScriptableObject
{
    [Header("Скорость движения"),Range(0,10)]
    public float MoveSpeed=5f;
    [Header("Скорость прыжка"),Range(0, 30)]
    public float JampSpeed = 15f;

    [Header("Расстояние до поверхности(коллайдера)"), Range(0, 1)]
    public float GndDistance=0.1f;

    [Header("Обновить")]
    public bool IsUpDate = false;
}
