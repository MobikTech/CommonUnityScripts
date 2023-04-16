using Mobik.Common.Utilities.PoolingFactory.Abstr;
using UnityEngine;

namespace Mobik.Common.Utilities.PoolingFactory.Core
{
    public struct DefaultCreationOptions<TItem> : ICreationOptions<TItem> where TItem : MonoBehaviour
    {
        public TItem Prefab { get; }
        public Vector3 SpawnPoint;
        public Quaternion Rotation;
        public Transform Parent;

        public DefaultCreationOptions(TItem prefab, Vector3 spawnPoint, Quaternion rotation, Transform parent)
        {
            Prefab = prefab;
            SpawnPoint = spawnPoint;
            Rotation = rotation;
            Parent = parent;
        }

        public void SetupCreationOptions(TItem item)
        {
            item.transform.position = SpawnPoint;
            item.transform.rotation = Rotation;
            item.transform.parent = Parent;
        }
    }
}