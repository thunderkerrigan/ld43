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
class Defeat : MusicStyle
{

    public AudioClip audioClip
    {
        get
        {
            return Resources.Load<AudioClip>("Audio/Defeat_screen_mastered");
        }
    }
}
class Winning : MusicStyle
{

    public AudioClip audioClip
    {
        get
        {
            return Resources.Load<AudioClip>("Audio/Winning_screen_mastered");
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

    private Coroutine interludeCoroutine;


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

    public void playInterludeClip(MusicStyle style)
    {
        if (interludeCoroutine == null)
        {
            interludeCoroutine = StartCoroutine(interlude(style));
        }

    }

    IEnumerator interlude(MusicStyle style)
    {
        AudioClip currentSong = musicSource.clip;
        int pauseTimestamp = musicSource.timeSamples;
        musicSource.clip = style.audioClip;
        musicSource.Play();
        yield return new WaitForSeconds(musicSource.clip.length);
        musicSource.clip = currentSong;
        musicSource.timeSamples = pauseTimestamp;
        musicSource.Play();
        interludeCoroutine = null;
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
