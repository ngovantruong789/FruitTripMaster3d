using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : TruongMonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;

    [Header("Link")]
    [SerializeField] protected AudioListSO audioListSO;

    [Header("Data")]
    [SerializeField] protected List<AudioType> audioTypes;
    [SerializeField] protected AudioSource musicBackground;

    protected override void Awake()
    {
        base.Awake();
        if (SoundManager.instance != null) Debug.LogError("Only 1 SoundManager allow to exists");
        SoundManager.instance = this;
    }

    protected override void LoadLink()
    {
        base.LoadLink();

        string path = "AudioList/AudioList";
        audioListSO = Resources.Load<AudioListSO>(path);

        foreach(AudioType audioType in audioListSO.audioTypes)
            audioTypes.Add(audioType);

        musicBackground = transform.GetComponent<AudioSource>();
        musicBackground.clip = audioListSO.musicBackground;
    }

    public void PlayAudioClip(string nameClip)
    {
        foreach (AudioType audioType in audioTypes)
            if (audioType.nameClip == nameClip) AudioSource.PlayClipAtPoint(audioType.audioClip, Camera.main.transform.position, audioType.volume);
    }

    public void SetMusicBackground(bool isPlay)
    {
        if(!isPlay)
            musicBackground.Stop();
    }
}
