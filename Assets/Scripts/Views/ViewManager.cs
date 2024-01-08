using System;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _levelCompletedScreen;
    
    private BoxController _boxController;
    
    public void Initialize (BoxController boxController)
    {
        _boxController = boxController;
    }

    private void Start()
    {
        _boxController.WasCollision += OpenGameOverScreen;
        _boxController.DropedDownOnFinishPoint += OpenLevelCompletedScreen;
    }

    private void OnDestroy()
    {
        _boxController.WasCollision -= OpenGameOverScreen;
        _boxController.DropedDownOnFinishPoint -= OpenLevelCompletedScreen;
    }

    private void OpenLevelCompletedScreen()
    {
        AllScreenClose();
        _levelCompletedScreen.gameObject.SetActive(true);
    }

    private void OpenGameOverScreen()
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
