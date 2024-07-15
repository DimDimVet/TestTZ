using UnityEngine;

[CreateAssetMenu(fileName = "MoveSettings", menuName = "ScriptableObjects/MoveSettings")]
public class MoveSettings : ScriptableObject
{
    [Header("�������� ��������"),Range(0,10)]
    public float MoveSpeed=5f;
    [Header("�������� ������"),Range(0, 10)]
    public float JampSpeed = 5f;

    [Header("������� ���� GND")]
    public string TagGnd;
    [Header("���������� �� �����������(����������)"), Range(0, 1)]
    public float GndDistance=0.1f;

    [Header("��������")]
    public bool IsUpDate = false;
}
