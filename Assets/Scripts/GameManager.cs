using System;
using UnityEngine;
using Views;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoxController _boxController;
    [SerializeField] private CargoTransferController _cargoTransferController;
   
    [SerializeField] private ScreenManager _screenManager;

    private void Awake()
    {
        _cargoTransferController.Initialize(_boxController);
    }

    private void Start()
        {
            _boxController.WasCollision += _screenManager.OpenGameOverScreen;
            _boxController.DroppedDownOnFinishPoint += _screenManager.OpenLevelCompletedScreen;
        }

        private void OnDestroy()
        {
            _boxController.WasCollision -= _screenManager.OpenGameOverScreen;
            _boxController.DroppedDownOnFinishPoint -= _screenManager.OpenLevelCompletedScreen;
        }
}

