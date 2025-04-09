using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    //for the music to play on start
    private void Start()
    {
        Play(audioClip);
    }

    public void Play(AudioClip musicToPlay)
    {
        audioSource.clip = musicToPlay;
        audioSource.Play();
    }
}
