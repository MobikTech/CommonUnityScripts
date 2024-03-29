#nullable enable
using System.Threading.Tasks;

namespace Mobik.Common.Utilities.SceneLoading
{
    public interface ISceneSwitcher
    {
        public event SceneLoadingStart SceneLoadingStarted;
        public event EventCompletion SceneLoadingEnded;

        public Task<LoadingResult> SwitchSceneAsync(string name);
    }
}
