using UnityEngine;

namespace Views
{
    public class ScreenManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private GameObject _levelCompletedScreen;

        public void OpenLevelCompletedScreen()
        {
            AllScreenClose();
            _levelCompletedScreen.gameObject.SetActive(true);
        }

        public void OpenGameOverScreen()
        {
            AllScreenClose();
            _gameOverScreen.gameObject.SetActive(true);
        }

        private void AllScreenClose()
        {
            _gameOverScreen.gameObject.SetActive(false);
            _levelCompletedScreen.gameObject.SetActive(false);
        }
    }
}
