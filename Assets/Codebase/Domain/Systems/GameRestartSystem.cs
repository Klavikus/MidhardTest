using Codebase.Domain.Components.Events;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Codebase.Domain.Systems
{
    public class GameRestartSystem : IEcsRunSystem
    {
        private const string BootstrapScene = "Bootstrap";

        private readonly EcsFilter<GameRestartRequestEvent> _eventEntities;

        public void Run()
        {
            if (_eventEntities.IsEmpty() == false)
            {
                SceneManager.LoadScene(BootstrapScene);
            }
        }
    }
}