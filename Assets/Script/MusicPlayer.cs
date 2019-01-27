using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] List<AudioClip> soundeffects;

    float randomTimeInterval;

    // Start is called before the first frame update
    void Start()
    {
        randomTimeInterval = UnityEngine.Random.Range(3.5f, 10.3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        countDownRandomTimer();
    }

    private void countDownRandomTimer()
    {
        randomTimeInterval -= Time.deltaTime;
        if (randomTimeInterval <= 0)
        {
            randomTimeInterval = UnityEngine.Random.Range(3.5f, 10.3f);

            if(soundeffects.Count > 0)
            {
                AudioSource.PlayClipAtPoint(soundeffects[UnityEngine.Random.Range(0, soundeffects.Count)], Camera.main.transform.position);
            }
        }
    }

}
