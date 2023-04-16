namespace Mobik.Common.Extensions
{
    public static class FloatExtensions
    {
        public static bool EqualsApproximately(this float value, float other, float approximation) =>
            System.Math.Abs(value - other) < approximation;
        
        public static bool LargerThanZero(this float value) => value > 0.0f;
        public static bool LessThanZero(this float value) => value < 0.0f;
        public static bool EqualsZero(this float value) => value == 0.0f;
        public static int GetSign(this float value) => value.LessThanZero() ? -1 : 1;
        public static bool IsSameSign(this float value, float other) => value.GetSign() == other.GetSign();
        public static float Absolute(float value) => value * GetSign(value);
    }
}