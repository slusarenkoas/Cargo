using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CargoTransferController : MonoBehaviour
{
    public UnityEvent <Vector3> StartDropCargo;
    
    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _finish;
    
    public void StartTransferCargo(LineRenderer lineRenderer)
    {
        var way = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(way);
        StartCoroutine(TransferCargoOnDefinedPath(way));
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
                transform.position = Vector3.MoveTowards(transform.position, nextStep, _speed * Time.deltaTime);
                
                if (transform.position.x < _finish.transform.position.x)
                {
                    StartDropCargo?.Invoke(_finish.transform.position);
                    yield break;
                }
                
                yield return null;
            }
        }
    }
    
}
