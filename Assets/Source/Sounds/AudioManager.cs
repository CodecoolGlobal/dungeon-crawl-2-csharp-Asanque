using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Audio;
using UnityEngine;
using Assets.Source.Sounds;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake()
    {
        foreach(var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    private void Start()
    {
        Play("MainTheme");
    }
    public void Play(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == name);
        sound.source.Play();
    }
}
