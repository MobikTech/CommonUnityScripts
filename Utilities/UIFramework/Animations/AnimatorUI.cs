using System;
using System.Collections.Generic;
using Mobik.Common.Utilities.UIFramework.Animations.Behaviours;
using UnityEngine;

namespace Mobik.Common.Utilities.UIFramework.Animations
{
    public class AnimatorUI
    {
        private readonly Dictionary<AnimationTypeUI, IAnimationBehaviour> _behaviours;

        public AnimatorUI()
        {
            _behaviours = new Dictionary<AnimationTypeUI, IAnimationBehaviour>
            {
                { AnimationTypeUI.SmoothScaling, new SmoothScalingBehaviour() },
                { AnimationTypeUI.SmoothFading, new SmoothFadingBehaviour() },
            };
        }

        public void AnimateVisualizing(Transform uiObject, AnimationTypeUI animationType, float visualizingTime, Action? callback = null)
        {
            _behaviours[animationType].AnimateVisualizing(uiObject, visualizingTime, callback);
        }
        
        public void AnimateHiding(Transform uiObject, AnimationTypeUI animationType, float hidingTime, Action? callback = null)
        {
            _behaviours[animationType].AnimateHiding(uiObject, hidingTime, callback);
        }
    }
}