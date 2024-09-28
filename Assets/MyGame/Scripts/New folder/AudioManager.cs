using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tao AudioManager
//Tao 1 GameObject ten la GameMusicSource co gan AudioSource,gan clip backgroundMusic de su dung
//Tao 4 ChannelSource co AudioSource, keo tha, de su dung sfx
//Tao 2 Button de co the mute music va sfx
//Tao 2 slider de thay doi volume music va sfx
//Muon su dung SFX nao thi dung Singleton
public class AudioManager : Singleton<AudioManager>
{
    [Space(10), Header("Music")]
    [SerializeField] AudioClip backgroundMusic;

    [SerializeField] AudioSource gameMusicSource;
    [Space(10), Header("Sound effects")]

    [SerializeField] List<AudioSource> channelSource = new List<AudioSource>();
    [SerializeField] int channel;
    [SerializeField] AudioClip sfx;
    [SerializeField] List<AudioClip> sfxList;
    [SerializeField] int index;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        PlayBackgroundMusic(backgroundMusic);
    }
    public enum Type_Sfx
    {
        //Them sfx vao day
    }
    public void PlayBackgroundMusic(AudioClip clip)
    {
        gameMusicSource.clip = clip;
        gameMusicSource.Play();
        gameMusicSource.loop = true;
    }
    public void PlaySfx(int index)
    {
        channelSource[channel].PlayOneShot(sfxList[index]);
        channel++;
        if (channel == channelSource.Count)
        {
            channel = 0;
        }
    }
    public void PlaySfx(Type_Sfx typeSfx)
    {
        channelSource[channel].PlayOneShot(sfxList[(int) typeSfx]);
        channel++;
        if (channel == channelSource.Count)
        {
            channel = 0;
        }
    }
    public void ToggleMusic()
    {
        gameMusicSource.mute = !gameMusicSource.mute;
    }

    public void ToggleSfx()
    {
        for (int i = 0; i < channelSource.Count; i++)
            channelSource[i].mute = !channelSource[i].mute;
    }

    public void MusicVolume(float volume)
    {
        gameMusicSource.volume = volume;
    }
    public void SfxVolume(float volume)
    {
        for (int i = 0; i < channelSource.Count; i++)
            channelSource[i].volume = volume;
    }

}

