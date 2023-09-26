using Codebase.Domain.Components;
using Codebase.Domain.Components.Tags;
using Codebase.Infrastructure;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Domain.Systems
{
    internal sealed class FollowMouseSystem :IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<TransformComponent, FollowObjectTag> _entities;
        private readonly EcsWorld _world;
        private readonly Camera _mainCamera;
        private readonly StaticData _staticData;
        
        private float _followingHeight;
        
        public void Init()
        {
            _followingHeight = _staticData.FollowingHeight;
        }

        public void Run()
        {
            foreach (int entity in _entities)
            {
                Transform transform = _entities.Get1(entity).Value;
                Vector3 newPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                newPosition.z = -_followingHeight;
                transform.position = newPosition;
            }
        }
    }
}