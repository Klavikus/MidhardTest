using Codebase.Domain.Components.Events;
using Codebase.Domain.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Infrastructure
{
    public class CompositionRoot : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private Camera _mainCamera;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems
                .Add(new GridInitSystem())
                .Add(new FollowObjectSpawnSystem())
                .OneFrame<PlaceObjectRequestEvent>()
                .OneFrame<GameRestartRequestEvent>()
                .Add(new InputSystem())
                .Add(new FollowMouseSystem())
                .OneFrame<FollowObjectSpawnRequestEvent>()
                .Add(new PlaceObjectSystem())
                .Add(new GameRestartSystem())
                .Inject(_staticData)
                .Inject(_mainCamera)
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems == null)
                return;

            _systems.Destroy();
            _world.Destroy();
        }
    }
}