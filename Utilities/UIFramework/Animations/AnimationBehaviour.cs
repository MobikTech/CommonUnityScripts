using System;
using UnityEngine;

namespace Mobik.Common.Utilities.UIFramework.Animations
{
    internal abstract class AnimationBehaviour
    {
        public abstract void AnimateVisualizing(Transform uiObject, float visualizingTime, Action? callback);
        public abstract void AnimateHiding(Transform uiObject, float hidingTime, Action? callback);
    }
}