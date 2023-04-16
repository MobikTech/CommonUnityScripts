using UnityEngine;

namespace Mobik.Common.Extensions
{
    public static class Vector3Extensions
    {
        public static bool EqualsApproximately(this Vector3 value, Vector3 other, float approximation) =>
            System.Math.Abs(value.x - other.x) < approximation &&
            System.Math.Abs(value.y - other.y) < approximation &&
            System.Math.Abs(value.z - other.z) < approximation;
    }
}