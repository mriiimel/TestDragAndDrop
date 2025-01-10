using UnityEngine;
using Zenject;

public class AppleController : IInitializable,ITickable
{
    private AppleModel _model;
    private AppleView _view;
    private Camera _camera;
    private Vector3 _offset;

    private float _zCoordinate;
    private bool _isDragging = false;

    public AppleController(AppleModel appleModel)
    {
        _model = appleModel;
        _zCoordinate = appleModel.AppleTransform.position.z;
        _view = appleModel.AppleView;
        
        
    }

    private void ZCoordinateSeting()
    {
        _zCoordinate = _view.transform.position.y;
        if (_zCoordinate <= _model.LayerOffset.HighestMidlegroundLimit & _zCoordinate >= _model.LayerOffset.LowerMidlegroundLimit)
        {
            _view.gameObject.layer = LayerMask.NameToLayer(_model.LayerName.MidleGroundLayer);
        }
        if (_zCoordinate <= _model.LayerOffset.HighestForegroundLimit & _zCoordinate >= _model.LayerOffset.LoverForegroundLimit)
        {
            _view.gameObject.layer = LayerMask.NameToLayer(_model.LayerName.ForeGroundLayer);
        }
        if (_zCoordinate >= _model.LayerOffset.LowerBackgroundLimit & _zCoordinate <= _model.LayerOffset.HighestBackgroundLimit)
        {
            _view.gameObject.layer = LayerMask.NameToLayer(_model.LayerName.BackGroundLayer);
        }
    }

    private void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = _camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, _camera.WorldToScreenPoint(_model.AppleTransform.position).z));

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (IsTouchingApple(touchPosition))
                    {
                        _offset = _model.AppleTransform.position - touchPosition;
                        _isDragging = true;
                        _view.DisableCollider(); 
                    }
                    break;

                case TouchPhase.Moved:
                    if (_isDragging)
                    {
                        Vector3 newPosition = touchPosition + _offset;
                        _model.AppleTransform.position = new Vector3(newPosition.x, newPosition.y, _model.AppleTransform.position.z);
                    }
                    break;

                case TouchPhase.Ended:
                    _isDragging = false;
                    _view.EnebleCollider(); 
                    break;
            }
        }
    }

    private bool IsTouchingApple(Vector3 touchPosition)
    {
        Collider2D col = _view.GetComponent<Collider2D>();
        return col == Physics2D.OverlapPoint(touchPosition);
    }
    public void Initialize()
    {
        _zCoordinate = _view.transform.position.z; 
        _camera = Camera.main;
        Input.simulateMouseWithTouches = true;
    }

    public void Tick()
    {
        ZCoordinateSeting();
        TouchInput();


    }
}
