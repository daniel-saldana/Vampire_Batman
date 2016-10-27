using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Managers
{
    public class AudioManager : MonoBehaviour
    {
        public List<ExtendedSounds> BackgroundSounds;

        public ExtendedSounds LoopingClipSounds;

        private List<GameObject> _loopingSounds;
        private GameObject _currentLoopingSound;
        private int _currentLoopingSoundIndex;

        public bool IsLoopingSoundsActive;
        public bool IsBackgroundSoundsActive;

        public GameObject SoundPrefab;

        #endregion

        #region Initialization

        public void Awake()
        {
            if (_loopingSounds == null)
                _loopingSounds = new List<GameObject>();

            if (BackgroundSounds == null)
                BackgroundSounds = new List<ExtendedSounds>();
        }

        public void Start()
        {
            foreach (var loopingClipSound in LoopingClipSounds.Clips)
            {
                GameObject soundObject = Instantiate(SoundPrefab) as GameObject;
                if (soundObject != null)
                {
                    soundObject.GetComponent<AudioSource>().clip = loopingClipSound;
                    _loopingSounds.Add(soundObject);
                }
            }

            InitializeBackgroundSounds();
        }

        private void InitializeBackgroundSounds()
        {
            foreach (var backgroundSound in BackgroundSounds)
            {
                foreach (var clip in backgroundSound.Clips)
                {
                    GameObject soundObject = Instantiate(SoundPrefab) as GameObject;
                    if (soundObject != null)
                    {
                        soundObject.GetComponent<AudioSource>().clip = clip;
                        backgroundSound.AddSource(soundObject);
                    }
                }
            }
        }

        #endregion

        #region Update

        public void Update()
        {
            if (IsLoopingSoundsActive && _loopingSounds.Count > 0)
            {
                var needToPlay = false;

                // No current sound
                if (_currentLoopingSound == null)
                {
                    _currentLoopingSoundIndex = 0;
                    needToPlay = true;
                }
                else
                {
                    // Need to play the next sound
                    if (!_currentLoopingSound.GetComponent<AudioSource>().isPlaying)
                    {
                        needToPlay = true;
                        _currentLoopingSoundIndex++;

                        // Loop to the first item
                        if (_currentLoopingSoundIndex >= _loopingSounds.Count)
                        {
                            _currentLoopingSoundIndex = 0;
                        }
                    }
                }

                if (needToPlay)
                {
                    _currentLoopingSound = _loopingSounds.ElementAtOrDefault(_currentLoopingSoundIndex);
                    if (_currentLoopingSound != null)
                    {
                        _currentLoopingSound.GetComponent<AudioSource>().panStereo = LoopingClipSounds.Pan;
                        _currentLoopingSound.GetComponent<AudioSource>().volume = LoopingClipSounds.Volume;
                        _currentLoopingSound.Play();
                    }
                }
            }
            else
            {
                // Pause current sound
                if (_currentLoopingSound != null)
                    _currentLoopingSound.GetComponent<AudioSource>().Pause();
            }

            if (IsBackgroundSoundsActive)
            {
                foreach (var backgroundSound in BackgroundSounds)
                {
                    if (backgroundSound.Delay <= 0f)
                    {
                        backgroundSound.Delay = Random.Range(backgroundSound.DelayMin, backgroundSound.DelayMax);
                    }
                    else
                    {
                        backgroundSound.UpdateCurrentDelay(Time.deltaTime);

                        if (!backgroundSound.CanPlay())
                            continue;

                        backgroundSound.Delay = Random.Range(backgroundSound.DelayMin, backgroundSound.DelayMax);
                        backgroundSound.RandomPlay();
                    }
                }
            }
        }

        #endregion
    }
}

