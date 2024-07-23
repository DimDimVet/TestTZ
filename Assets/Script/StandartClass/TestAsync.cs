using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class TestAsync : MonoBehaviour
{
    private bool isStopClass = false, isRun = false;
    private void OnEnable()
    {

    }
    void Start()
    {

        SetClass();
    }
    //
//    var cts = new CancellationTokenSource();

//    cancelButton.onClick.AddListener(() =>
//{
    
    
//    cts.Cancel();
//});
public async UniTaskVoid LoadManyAsync()
{
    var (a, b, c) = await UniTask.WhenAll(
        LoadAsSprite("foo"),
        LoadAsSprite("bar"),
        LoadAsSprite("baz"));
}
private async UniTask<Sprite> LoadAsSprite(string path)
{
    var resource = await Resources.LoadAsync<Sprite>(path);
    return (resource as Sprite);
}
//
private void SetClass()
{
    if (!isRun)
    {
        isRun = true;
    }
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
