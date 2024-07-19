using UnityEngine;
using UnityEngine.UI;

public class DropInventary : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject test;

    private bool isStopClass = false, isRun = false;
    private void OnEnable()
    {

    }
    void Start()
    {
        SetClass();
        
        button.onClick.AddListener(ParentSetObject);
    }
    private void SetClass()
    {
        if (!isRun)
        {
            isRun = true;
        }
    }
    private void ParentSetObject()
    {
        grid.transform.SetParent(test.transform);
    }
    void FixedUpdate()
    {
        if (isStopClass) { return; }
        if (!isRun) { SetClass(); }
        RunUpdate();
    }
    void Update()
    {

    }
    private void RunUpdate()
    {

    }
    private void OnDisable()
    {

    }
}
