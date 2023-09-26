using Codebase.Presentation.EntityActors;
using UnityEngine;

namespace Codebase.Infrastructure
{
    [CreateAssetMenu(menuName = "Data/Create StaticData", fileName = "StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [field: SerializeField] public Vector2Int GridSize { get; private set; }
        [field: SerializeField] public float CellSize { get; private set; }
        [field: SerializeField] public CellObject OddCellPrefab { get; private set; }
        [field: SerializeField] public CellObject EvenCellPrefab { get; private set; }
        [field: SerializeField] public FollowObject FollowObjectPrefab { get; private set; }
        [field: SerializeField] public float FollowingHeight { get; private set; }
    }
}