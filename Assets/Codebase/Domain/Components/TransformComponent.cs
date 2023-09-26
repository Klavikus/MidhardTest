using UnityEngine;

namespace Codebase.Domain.Components
{
    public struct TransformComponent
    {
        public readonly Transform Value;

        public TransformComponent(Transform value)
        {
            Value = value;
        }
    }
}