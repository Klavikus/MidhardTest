using Codebase.Domain.Components;
using Leopotam.Ecs;

namespace Codebase.Presentation.EntityActors
{
    public class CellObject : EntityActor
    {
        protected override void InitComponents()
        {
            Entity
                .Replace(new TransformComponent(transform))
                .Replace(new CellComponent());
        }
    }
}