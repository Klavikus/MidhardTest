using UnityEngine;

namespace Codebase.Domain.Components
{
    public struct CellComponent
    {
        public readonly Vector3 CenterCoordinates;
        public readonly float Size;
      
        private bool _isEmpty;

        public CellComponent(Vector3 centerCoordinates, float size, bool isEmpty)
        {
            CenterCoordinates = centerCoordinates;
            Size = size;
            _isEmpty = isEmpty;
        }

        public bool IsEmpty => _isEmpty;

        public void Fill() => _isEmpty = false;
    }
}