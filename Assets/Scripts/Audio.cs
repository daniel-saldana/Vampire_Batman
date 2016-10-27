﻿using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class Audio : MonoBehaviour
    {
        public string Name;

        public float VolumeMin = 0f;
        public float VolumeMax = 1f;
        public float Volume;

        public float PanMin = -1f;
        public float PanMax = 1f;
        public float Pan;

        public float DelayMin = 2f;
        public float DelayMax = 10f;
        public float Delay;

        private float _currentDelay;

        public List<AudioClip> Clips;
        private List<GameObject> _sources;

        public ExtendedSounds()
        {
            Clips = new List<AudioClip>();
            _sources = new List<GameObject>();
        }

        public void UpdateCurrentDelay(float delay)
        {
            _currentDelay += delay;
        }

        public bool CanPlay()
        {
            if (_sources != null && _sources.Count > 1 && _currentDelay >= Delay)
                return true;
            return false;
        }

        /// <summary>
        /// Play a sound randomly
        /// </summary>
        public void RandomPlay()
        {
            Volume = UnityEngine.Random.Range(VolumeMin, VolumeMax);
            Pan = UnityEngine.Random.Range(PanMin, PanMax);

            var soundIndex = UnityEngine.Random.Range(0, _sources.Count);
            var source = _sources.ElementAtOrDefault(soundIndex);
            if (source != null)
            {
                source.GetComponent<AudioSource>().panStereo = Pan;
                source.GetComponent<AudioSource>().volume = Volume;
                source.Play();
            }
            _currentDelay = 0;
        }

        public void AddSource(GameObject soundObject)
        {
            _sources.Add(soundObject);
        }
    }
}
    }
}
