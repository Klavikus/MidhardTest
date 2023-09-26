using Codebase.Domain.Components.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Domain.Systems
{
    internal sealed class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly Camera _mainCamera;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(mousePosition);

                _world.NewEntity().Replace(new PlaceObjectRequestEvent(worldPosition));
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _world.NewEntity().Replace(new GameRestartRequestEvent());
            }
        }
    }
}