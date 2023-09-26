using UnityEngine;

namespace Codebase.Domain.Components.Events
{
    public struct FollowObjectSpawnRequestEvent
    {
        public readonly Vector3 SpawnPosition;

        public FollowObjectSpawnRequestEvent(Vector3 spawnPosition)
        {
            SpawnPosition = spawnPosition;
        }
    }
}