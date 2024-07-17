using UnityEngine;

[CreateAssetMenu(fileName = "DropSettings", menuName = "ScriptableObjects/DropSettings")]
public class DropSettings : ScriptableObject
{
    [Header("Мусор"), Range(-10, 10)]
    public int Trash = 0;
    [Header("Цена"), Range(0, 100)]
    public int Price = 50;

}
