﻿using System.Threading.Tasks;
using UnityEngine;

namespace Mobik.Common.Utilities.SoundSystem
{
    internal class AudioEntity
    {
        internal AudioEntity(AudioSource audioSource, AudioEntitySettings audioEntitySettings)
        {
            _audioSource = audioSource;
            _audioSource.clip = audioEntitySettings.AudioClip;
            _audioSource.loop = audioEntitySettings.IsLooping;
            _audioSource.volume = audioEntitySettings.Volume;
            AudioEntityID = audioEntitySettings.AudioEntityID;
        }

        internal AudioEntity(AudioSource audioSource, AudioEntitySettings audioEntitySettings, SpatialAudioParameters spatialAudioParameters) : this(audioSource, audioEntitySettings)
        {
            _soundSourceTransform = spatialAudioParameters.SoundSource;
            _audioSource.spatialBlend = 1f;
            _isSpatial = true;
        }

        internal AudioSource AudioSource => _audioSource;
        internal uint AudioEntityID { get; }

        private readonly AudioSource _audioSource;
        private readonly bool _isSpatial = false;
        private readonly Transform _soundSourceTransform;


        internal async Task Play()
        {
            _audioSource.Play();
            while (_audioSource != null && _audioSource.isPlaying && _audioSource.gameObject.activeSelf)
            {
                if (_isSpatial)
                {
                    _audioSource.transform.position = _soundSourceTransform.position;
                }
                await Task.Yield();
            }
        }

        internal void StopPlaying()
        {
            _audioSource.Stop();
        }
    }
}