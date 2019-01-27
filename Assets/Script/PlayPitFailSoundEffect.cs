using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPitFailSoundEffect : MonoBehaviour
{
    [SerializeField] List<AudioClip> failSounds;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(failSounds[UnityEngine.Random.Range(0, failSounds.Count)], Camera.main.transform.position);
    }
}
