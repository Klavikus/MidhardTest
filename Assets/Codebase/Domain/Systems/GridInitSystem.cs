using Codebase.Domain.Components;
using Codebase.Infrastructure;
using Codebase.Presentation.EntityActors;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Domain.Systems
{
    internal sealed class GridInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly StaticData _staticData;

        public void Init()
        {
            float startX = -_staticData.GridSize.x * 0.5f + _staticData.CellSize * 0.5f;
            float startY = -_staticData.GridSize.y * 0.5f + _staticData.CellSize * 0.5f;

            for (int y = 0; y < _staticData.GridSize.y; y++)
            {
                for (int x = 0; x < _staticData.GridSize.x; x++)
                {
                    bool isEven = (x + y) % 2 == 0;
                    Vector3 newPosition = new Vector3
                    (
                        startX + x * _staticData.CellSize,
                        startY + y * _staticData.CellSize,
                        0
                    );

                    SpawnCell(newPosition, isEven);
                }
            }
        }

        private void SpawnCell(Vector3 position, bool isEven)
        {
            CellObject prefab = isEven ? _staticData.EvenCellPrefab : _staticData.OddCellPrefab;
            CellObject cell = Object.Instantiate(prefab, position, Quaternion.identity);
            cell.Init(_world);
            cell.Entity.Replace(new CellComponent(position, _staticData.CellSize, isEmpty: true));
        }
    }
}