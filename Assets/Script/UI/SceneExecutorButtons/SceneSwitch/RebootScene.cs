using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class RebootScene : MonoBehaviour
    {
        [SerializeField] private CustomButton rebootSceneButton;

        private IUIExecutor uiExecutor;

        [Inject]
        public void Init(IUIExecutor _uiExecutor)
        {
            uiExecutor = _uiExecutor;
        }
        private void Awake()
        {
            
        }
        private void OnEnable()
        {
            uiExecutor.LoadData();
            rebootSceneButton.OnExecutorButton += RebootButton;
        }
        private void RebootButton(int _hash, StatusCustomButton _status)
        {
            if (_status == StatusCustomButton.PointDown)
            {
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                //uiExecutor.ReBoot(currentScene);
                uiExecutor.LoadData();
            }
        }
    }
}