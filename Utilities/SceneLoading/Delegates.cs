#nullable enable
namespace Mobik.Common.Utilities.SceneLoading
{
    public delegate void SceneLoadingStart(LoadingProgress loadingProgress);
    public delegate void EventCompletion(LoadingResult loadingResult);
}