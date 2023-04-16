using System;

namespace Mobik.Common.Utilities.UIFramework.Animations
{
    [Serializable]
    internal class WidgetAnimationOptions
    {
        public AnimationTypeUI AnimationType = AnimationTypeUI.None;
        public float VisualizingTime;
        public float HidingTime;
    }
}