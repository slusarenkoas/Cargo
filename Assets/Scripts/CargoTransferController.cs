using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CargoTransferController : MonoBehaviour
{
    public UnityEvent <Vector3> StartDropCargo;
    public UnityEvent  DropBoxNotAtFinishPoint;
    
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _finish;

    private bool _wasCollision = false;
    private BoxController _boxController;

    public void Initialize (BoxController boxController)
    {
        _boxController = boxController;
    }
    
    public void StartTransferCargo(LineRenderer lineRenderer)
    {
        var way = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(way);
        StartCoroutine(TransferCargoOnDefinedPath(way));
    }
    
    private void Start()
    {
        _boxController.WasCollision += StopTransferCargo;
    }
    
    private void OnDestroy()
    {
        _boxController.WasCollision -= StopTransferCargo;
    }

    private void StopTransferCargo()
    {
        _wasCollision = true;
    }

    private IEnumerator TransferCargoOnDefinedPath(Vector3[] way)
    {
        if (way.Length < 1)
        {
            yield break;
        }

        foreach (var nextStep in way)
        {
            while (transform.position != nextStep)
            {
                if (_wasCollision)
                {
                    yield break;    
                }
                
                transform.position = Vector3.MoveTowards(transform.position, nextStep, _speed * Time.deltaTime);
                
                if (transform.position.x < _finish.transform.position.x)
                {
                    StartDropCargo?.Invoke(_finish.transform.position);
                    yield break;
                }
                
                yield return null;
            }
        }
        
        DropBoxNotAtFinishPoint?.Invoke();
    }
    
}
