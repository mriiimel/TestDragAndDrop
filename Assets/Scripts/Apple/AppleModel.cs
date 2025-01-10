using UnityEngine;

public class AppleModel 
{
    private readonly AppleView _appleView;
    private readonly GroundLayerNames _groundLayerNames;
    private readonly LayersOffsetZCoord _layerOffset;

    private Transform _appleTransform;

    public AppleModel(AppleView appleView,GroundLayerNames groundLayerNames,LayersOffsetZCoord layersOffsetZCoord)
    {
        _appleView = appleView;
        _appleTransform = _appleView.transform;
        _groundLayerNames = groundLayerNames;
        _layerOffset = layersOffsetZCoord;
    }

    public AppleView AppleView => _appleView;
    public Transform AppleTransform { get => _appleTransform; set => _appleTransform = value; }
    public GroundLayerNames LayerName => _groundLayerNames;

    public LayersOffsetZCoord LayerOffset => _layerOffset;
}
