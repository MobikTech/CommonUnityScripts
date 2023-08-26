using System;
using System.Collections.Generic;
using System.Linq;
using Mobik.Common.Core;
using Mobik.Common.Utilities.UIFramework.Animations;
using UnityEngine;

namespace Mobik.Common.Utilities.UIFramework
{
    public abstract class UISceneManager : MonoBehaviourCached, IViewVisualizer
    {
        [SerializeField] protected List<UIView>? _startViews;
        private Dictionary<Type, UIView> _allViews = null!;
        private bool _isInitialized = false;

        private void Awake() => Initialize();

        public TView Visualize<TView, TOptions>(TOptions options) where TView : UIView where TOptions : IOptions
        {
            TView view = GetView<TView>();
            view.Open(options);
            return view;
        }

        public TView Hide<TView>() where TView : UIView
        {
            TView view = GetView<TView>();
            view.Close();
            return view;
        }

        public TView GetView<TView>() where TView : UIView
        {
            if (!_allViews.ContainsKey(typeof(TView)))
                throw new Exception($"Such UI View({typeof(TView).Name}) doesn't exist in this scene");

            TView view = (TView)_allViews[typeof(TView)];
            return view;
        }

        protected virtual void Initialize()
        {
            gameObject.SetActive(true);
            _allViews = GetViewsDict();
            _allViews.Values.ToList().ForEach(view => view.Initialize(this, new AnimatorUI()));
            _startViews?.ForEach(view => view.Open(IOptions.NoneOptions));
            _isInitialized = true;
        }

        private void OnDestroy()
        {
            if (!_isInitialized)
            {
                return;
            }
            _allViews.Values.ToList().ForEach(view => view.Dispose());
        }

        private Dictionary<Type, UIView> GetViewsDict()
        {
            List<UIView> views = GetComponentsInChildren<UIView>(true).ToList();
            Dictionary<Type, UIView> result = new Dictionary<Type, UIView>();
            views.ForEach(view => result.Add(view.ActualType, view));
            return result;
        }
    }
}