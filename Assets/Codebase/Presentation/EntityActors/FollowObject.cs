using Codebase.Domain.Components;
using Codebase.Domain.Components.Tags;
using Leopotam.Ecs;

namespace Codebase.Presentation.EntityActors
{
    public class FollowObject : EntityActor
    {
        protected override void InitComponents()
        {
            Entity
                .Replace(new TransformComponent(transform))
                .Replace(new FollowObjectTag());
        }
    }
}