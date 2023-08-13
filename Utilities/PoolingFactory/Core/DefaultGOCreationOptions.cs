using Mobik.Common.Utilities.PoolingFactory.Abstr;
using UnityEngine;

namespace Mobik.Common.Utilities.PoolingFactory.Core
{
    public readonly struct DefaultCreationOptions<TItem> : ICreationOptions<TItem> where TItem : MonoBehaviour
    {
        public TItem Prefab { get; }
        private readonly Vector3 _spawnPoint;
        private readonly Quaternion _rotation;
        private readonly Transform _parent;

        public DefaultCreationOptions(TItem prefab, Vector3 spawnPoint, Quaternion rotation, Transform parent)
        {
            Prefab = prefab;
            _spawnPoint = spawnPoint;
            _rotation = rotation;
            _parent = parent;
        }

        public void SetupCreationOptions(TItem item)
        {
            item.transform.position = _spawnPoint;
            item.transform.rotation = _rotation;
            item.transform.parent = _parent;
        }
    }
}