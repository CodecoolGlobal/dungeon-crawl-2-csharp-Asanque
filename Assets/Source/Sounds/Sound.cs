using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.Sounds
{
    public class PlayAudio: MonoBehaviour
    {
        public AudioSource audioSource;
        void Start()
        {
            audioSource.Play();
        }

    }
}
