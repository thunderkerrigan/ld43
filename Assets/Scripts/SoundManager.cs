using System.Collections;
using UnityEngine;

public interface MusicStyle
{
    AudioClip audioClip { get; }
}

class Epic : MusicStyle
{

    public AudioClip audioClip
    {
        get
        {
            return Resources.Load<AudioClip>("Audio/Ldjam43-Boss_fight-mastered-1");
        }
    }
}

class Chill : MusicStyle
{

    public AudioClip audioClip
    {
        get
        {
            return Resources.Load<AudioClip>("Audio/Ldjam43-Chill_sad-mastered-1");
        }
    }
}

class PVC : MusicStyle
{

    public AudioClip audioClip
    {
        get
        {
            return Resources.Load<AudioClip>("Audio/Synth Adventure Theme 2 (slow)");
        }
    }
}

public class SoundManager : MonoBehaviour
{

    public AudioSource efxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void changeMusicStyle(MusicStyle style)
    {
        musicSource.clip = style.audioClip;
        musicSource.Play();
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];
        efxSource.Play();
    }

}
