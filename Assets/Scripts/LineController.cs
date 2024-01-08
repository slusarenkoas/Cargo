using UnityEngine;
using UnityEngine.Events;

public class LineController : MonoBehaviour
{
    public UnityEvent<LineRenderer> StopDrawingLine;
    
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _minStepBetweenPositions = 0.5f;
    
    private Camera _camera;
    private bool _lineDrown = false;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (_lineDrown)
        {
            return;
        }
        
        if (Input.GetMouseButton(0))
        {
            DrawLine();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lineDrown = true;
            StopDrawingLine?.Invoke(_lineRenderer);
        }
    }

    private void DrawLine()
    {
        var previousPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
        var mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y,12.88f);
        var nextPosition = _camera.ScreenToWorldPoint(mousePosition);
        
        //exclude extra points
        var currentDistance = Vector3.Distance(nextPosition, previousPosition);

        if (!(currentDistance > _minStepBetweenPositions)) return;
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, nextPosition);
    }
}
