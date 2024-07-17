using UnityEngine;

[CreateAssetMenu(fileName = "DropSettings", menuName = "ScriptableObjects/DropSettings")]
public class DropSettings : ScriptableObject
{
    [Header("�����"), Range(-10, 10)]
    public int Trash = 0;
    [Header("����"), Range(0, 100)]
    public int Price = 50;

}
