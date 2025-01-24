using Unity.VisualScripting;
using UnityEngine;

public class SoundPlayer: MonoBehaviour
{
    private AudioSource backgroundSource;
    private AudioSource musicSource;
    private AudioSource bubbleSource;
    private AudioSource walkingSource;
    
    public AudioClip backgroundClip;
    public AudioClip musicClip;
    public AudioClip bubbleClip;
    public AudioClip walkingClip;

    private void Start()
    {
        backgroundSource = this.AddComponent<AudioSource>();
        musicSource = this.AddComponent<AudioSource>();
        bubbleSource = this.AddComponent<AudioSource>();
        walkingSource = this.AddComponent<AudioSource>();
        
        // config
        SetConfig();

        _instance = this;
    }

    private void SetConfig()
    {   
        walkingSource.clip = walkingClip;
        
        bubbleSource.clip = bubbleClip;
        
        backgroundSource.loop = true;
        backgroundSource.clip = backgroundClip;
        backgroundSource.volume = 0.5f;
        backgroundSource.Play();
        
        musicSource.loop = true;
        musicSource.clip = musicClip;
        musicSource.volume = 0.5f;
        musicSource.Play();
    }

    private static SoundPlayer _instance;

    public static void PlayBubble() =>
        _instance.bubbleSource.PlayOneShot(_instance.bubbleClip);

    public static void PlayWalking()
    {  
        if(!_instance.walkingSource.isPlaying )
            _instance.walkingSource.Play();
    }

    
    public static void PauseWalking()=>
        _instance.walkingSource.Pause();
} 