using Codebase.Domain.Components.Events;
using Codebase.Infrastructure;
using Codebase.Presentation.EntityActors;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Domain.Systems
{
    internal sealed class FollowObjectSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<FollowObjectSpawnRequestEvent> _requestEntities;
        private readonly EcsWorld _world;
        private readonly StaticData _staticData;

        public void Init()
        {
            SpawnFollowObject(Vector3.zero);
        }

        public void Run()
        {
            foreach (int requestEntity in _requestEntities)
                SpawnFollowObject(_requestEntities.Get1(requestEntity).SpawnPosition);
        }

        private void SpawnFollowObject(Vector3 spawnPosition)
        {
            FollowObject followObject = Object.Instantiate(_staticData.FollowObjectPrefab, spawnPosition, Quaternion.identity);
            followObject.Init(_world);
        }
    }
}