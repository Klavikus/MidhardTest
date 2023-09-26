using Codebase.Domain.Components;
using Codebase.Domain.Components.Events;
using Codebase.Domain.Components.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Domain.Systems
{
    internal sealed class PlaceObjectSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlaceObjectRequestEvent> _eventEntities;
        private readonly EcsFilter<TransformComponent, FollowObjectTag> _followEntities;
        private readonly EcsFilter<CellComponent> _cellEntities;

        private readonly EcsWorld _world;
        private readonly Camera _mainCamera;

        public void Run()
        {
            foreach (int placeObjectEvent in _eventEntities)
            {
                Vector3 placeWorldPosition = _eventEntities.Get1(placeObjectEvent).WorldPosition;

                foreach (int cellEntity in _cellEntities)
                {
                    ref var cellComponent = ref _cellEntities.Get1(cellEntity);

                    if (CheckCellPosition(placeWorldPosition, cellComponent) && cellComponent.IsEmpty)
                    {
                        foreach (int followEntity in _followEntities)
                        {
                            cellComponent.Fill();

                            Transform transform = _followEntities.Get1(followEntity).Value;
                            transform.position = cellComponent.CenterCoordinates;
                           
                            _followEntities
                                .GetEntity(followEntity)
                                .Del<FollowObjectTag>();
                        }

                        _world.NewEntity().Replace(new FollowObjectSpawnRequestEvent(cellComponent.CenterCoordinates));
                    }
                }
            }
        }

        private bool CheckCellPosition(Vector3 worldPosition, CellComponent cellComponent)
        {
            float minX = cellComponent.CenterCoordinates.x - cellComponent.Size * 0.5f;
            float maxX = cellComponent.CenterCoordinates.x + cellComponent.Size * 0.5f;
            float minY = cellComponent.CenterCoordinates.y - cellComponent.Size * 0.5f;
            float maxY = cellComponent.CenterCoordinates.y + cellComponent.Size * 0.5f;

            return worldPosition.x <= maxX && worldPosition.x >= minX &&
                   worldPosition.y <= maxY && worldPosition.y >= minY;
        }
    }
}