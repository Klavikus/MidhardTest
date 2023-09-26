using Leopotam.Ecs;
using UnityEngine;

namespace Codebase.Presentation.EntityActors
{
    public abstract class EntityActor : MonoBehaviour
    {
        [SerializeField] private bool _needDestroyOnComplete;

        private EcsEntity _entity;

        public EcsEntity Entity => _entity;

        public void Init(EcsWorld world)
        {
            _entity = world.NewEntity();
            InitComponents();
            DestroyActor();
        }

        private void DestroyActor()
        {
            if (_needDestroyOnComplete)
                Destroy(this);
        }

        protected abstract void InitComponents();
    }
}