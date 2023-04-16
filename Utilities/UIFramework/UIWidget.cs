namespace Mobik.Common.Utilities.UIFramework
{
    public abstract class UIWidget : MonoBehaviourCached
    {
        public bool IsActive { get; private set; }

        internal virtual void Initialize() => gameObject.SetActive(false);

        internal virtual void Visualize<TOptions>(TOptions options) where TOptions : IOptions
        {
            gameObject.SetActive(true);
            IsActive = true;
        }

        internal virtual void Hide()
        {
            gameObject.SetActive(false);
            IsActive = false;
        }
    }
}
