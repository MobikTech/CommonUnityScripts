namespace Mobik.Common.Utilities.SoundSystem
{
    public interface IAudioSystem
    {
        public void PlayAudio(uint audioID, SpatialAudioParameters? spatialAudioParameters = null);
        public void StopAudio(uint audioID);
    }
}