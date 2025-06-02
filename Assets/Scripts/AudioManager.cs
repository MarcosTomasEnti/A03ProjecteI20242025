using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager Instance;

    [SerializeField]
    AudioSource musicSource;
    [SerializeField]
    AudioSource enemySource;
    [SerializeField]
    AudioSource playerSource;
    [SerializeField]
    AudioSource ambienceSource;
    [SerializeField]
    AudioSource itemSource;

    [SerializeField]
    AudioClip levelMusicClip;

    [SerializeField]
    AudioClip menuMusicClip;

    public static float musicVolume = 1;
    public static float enemiesVolume = 1;
    public static float playerVolume = 1;
    public static float ambienceVolume = 1;
    public static float itemsVolume = 1;
    public static float masterVolume = 1;

    public enum AudioType
    {Music, Enemies, Player, Ambience, Items};


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }    
        
    }
    private void Update()
    {
        musicSource.volume = masterVolume * musicVolume;
        enemySource.volume = masterVolume * enemiesVolume;
        playerSource.volume = masterVolume * playerVolume;
        ambienceSource.volume = masterVolume * ambienceVolume;
        itemSource.volume = masterVolume * itemsVolume;

    }

    public static void levelMusic()
    {
        Instance.PlayAudioClip(Instance.levelMusicClip, AudioType.Music);
    }

    public static void menuMusic()
    {
        Instance.PlayAudioClip(Instance.menuMusicClip, AudioType.Music);
    }

    public void PlayAudioClip(AudioClip clip, AudioType type)
    {
        if (clip != null)
        {
            switch(type)
            {
                case AudioType.Music:
                    
                    musicSource.clip = clip;
                    musicSource.Play();
                break;
                case AudioType.Enemies:
                    
                    enemySource.clip = clip;
                    enemySource.Play();
                break;
                case AudioType.Player:
                    
                    playerSource.clip = clip;
                    playerSource.Play();
                break;
                case AudioType.Ambience:
                    
                    ambienceSource.clip = clip;
                    ambienceSource.Play();
                break;
                case AudioType.Items:
                    itemSource.clip = clip;
                    itemSource.Play();
                break;
                
            }
            
        }
       
    }
}
