using Mobik.Common.Core;

namespace Mobik.Common.Utilities.UIFramework
{
    public interface IViewVisualizer
    {
        public TView Visualize<TView, TOptions>(TOptions options) where TView : UIView where TOptions : IOptions;
        public TView Hide<TView>() where TView : UIView;
        public TView GetView<TView>() where TView : UIView;
    }
}