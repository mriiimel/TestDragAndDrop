using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private AppleView _appleView;
    [SerializeField] private Transform _appleSpawn;

    private AppleView m_AppleView;


    public override void InstallBindings()
    {
        LayersNameBindings();
        GroundOffsetsBinding();
        AppleBindings();
    }
    private void GroundOffsetsBinding()
    {
        Container.Bind<LayersOffsetZCoord>().AsSingle();
    }

    private void LayersNameBindings()
    {
        Container.Bind<GroundLayerNames>().AsSingle();
    }

    private void AppleBindings()
    {
        m_AppleView = Container.InstantiatePrefabForComponent<AppleView>(_appleView, _appleSpawn.position, Quaternion.identity, null);
        Container.Bind<AppleView>().FromInstance(m_AppleView).AsSingle();
        Container.Bind<AppleModel>().AsSingle();
        Container.BindInterfacesAndSelfTo<AppleController>().AsSingle();
        
    }
}