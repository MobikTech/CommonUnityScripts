using System;
using Mobik.Common.Utilities.UIFramework.Animations;
using UnityEngine;

namespace Mobik.Common.Utilities.UIFramework
{
    public abstract class UIWidget : MonoBehaviourCached
    {
        public event Action? VisualizingStarted;
        public event Action? VisualizingFinished;
        
        public event Action? HidingStarted;
        public event Action? HidingFinished;
        
        public bool IsActive { get; private set; }

        [SerializeField] private WidgetAnimationOptions _widgetAnimationOptions;
        private bool _shouldAnimate;
        private AnimatorUI _animatorUI;

        internal virtual void Initialize(AnimatorUI animatorUI)
        {
            gameObject.SetActive(false);
            _animatorUI = animatorUI;
            _shouldAnimate = _widgetAnimationOptions.AnimationType != AnimationTypeUI.None;
        }

        internal virtual void Visualize<TOptions>(TOptions options) where TOptions : IOptions
        {
            gameObject.SetActive(true);
            IsActive = true;

            if (!_shouldAnimate) return;
            
            VisualizingStarted?.Invoke();
            _animatorUI.AnimateVisualizing(transform, _widgetAnimationOptions.AnimationType, 
                _widgetAnimationOptions.VisualizingTime, () => VisualizingFinished?.Invoke());
        }

        internal virtual void Hide()
        {
            IsActive = false;

            if (_shouldAnimate)
            {
                HidingStarted?.Invoke();
                _animatorUI.AnimateHiding(transform, _widgetAnimationOptions.AnimationType,
                    _widgetAnimationOptions.HidingTime, () =>
                    {
                        gameObject.SetActive(false);
                        HidingFinished?.Invoke();
                    });
            }

            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
