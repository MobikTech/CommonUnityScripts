using System;
using UnityEngine;

namespace Mobik.Common.Utilities.UIFramework.Animations
{
    internal interface IAnimationBehaviour
    {
        public void AnimateVisualizing(Transform uiObject, float visualizingTime, Action? callback);
        public void AnimateHiding(Transform uiObject, float hidingTime, Action? callback);
    }
}