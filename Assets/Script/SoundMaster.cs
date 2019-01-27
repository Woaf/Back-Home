using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMaster : MonoBehaviour
{
    AudioListener listener;
    AudioSource source;

    Dictionary<string, AudioClip> audioclips = new Dictionary<string, AudioClip>();

    // Főmenü hangjai
    [SerializeField] AudioClip BGS_rain,
        Rnd_thunder, Rnd_rain_and_thunder,
        Rnd_lightning, Event_bark1, Event_bark2;

    // Hub

    // Kutyás pálya esővel

    // Labirintusos pálya

    void Awake()
    {
        listener = (AudioListener)FindObjectOfType(typeof(AudioListener));
        if (listener == null)
        {
            listener = gameObject.AddComponent(typeof(AudioListener)) as AudioListener;
        }
        source = (AudioSource)FindObjectOfType(typeof(AudioSource));
        if (source == null)
        {
            source = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        }
    }

    private void Start()
    {
        audioclips.Add("BGS_rain", BGS_rain);
        audioclips.Add("Rnd_thunder", Rnd_thunder);
        audioclips.Add("Rnd_rain_and_thunder", Rnd_rain_and_thunder);
        audioclips.Add("Rnd_lightning", Rnd_lightning);
        audioclips.Add("Event_bark1", Event_bark1);
        audioclips.Add("Event_bark2", Event_bark2);
        PlaySound("BGS_rain");
    }

    public void PlaySound(string clipname)
    {
        source.PlayOneShot(audioclips[clipname]);
    }

    public void StopSound()
    {
        source.Stop();
    }

}
