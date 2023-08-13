﻿using System;
using System.Collections.Generic;
using System.Linq;
using Mobik.Common.Utilities.UIFramework.Animations;
using UnityEngine;

namespace Mobik.Common.Utilities.UIFramework
{
    public abstract class UIView : MonoBehaviourCached
    {
        public event Action? HasOpened;
        public event Action? HasClosed;
        public abstract Type ActualType { get; }

        [SerializeField] private List<UIWidget>? _startWidgets;
        private List<UIWidget>? _childWidgets;
        protected IViewVisualizer _viewVisualizer = null!;


        internal virtual void Initialize(IViewVisualizer viewVisualizer, AnimatorUI animatorUI)
        {
            _viewVisualizer = viewVisualizer;
            _childWidgets = GetComponentsInChildren<UIWidget>().ToList();
            _childWidgets.ForEach(widget => widget.Initialize(animatorUI));
            gameObject.SetActive(false);
        }
        
        public virtual void Open<TOptions>(TOptions options) where TOptions : IOptions
        {
            gameObject.SetActive(true);
            _startWidgets?.ForEach(widget => widget.Visualize(options));
            HasOpened?.Invoke();
        }

        public virtual void Close()
        {
            _childWidgets?
                .Where(widget => widget.IsActive)
                .ToList()
                .ForEach(widget => widget.Hide());
            gameObject.SetActive(false);
            HasClosed?.Invoke();
        }
    }
}
