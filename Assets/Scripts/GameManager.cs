using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BoxController _boxController;
    [SerializeField] private CargoTransferController _cargoTransferController;
   
    [SerializeField] private ViewManager _viewManager;

    private void Awake()
    {
        _viewManager.Initialize(_boxController);
        _cargoTransferController.Initialize(_boxController);
    }
}

