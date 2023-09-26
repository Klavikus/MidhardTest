using UnityEngine;

namespace Codebase.Domain.Components.Events
{
    public struct PlaceObjectRequestEvent
    {
        public readonly Vector3 WorldPosition;

        public PlaceObjectRequestEvent(Vector3 worldPosition)
        {
            WorldPosition = worldPosition;
        }
    }
}