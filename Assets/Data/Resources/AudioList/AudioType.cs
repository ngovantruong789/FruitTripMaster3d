using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioType
{
    public string nameClip;
    public AudioClip audioClip;
    [SerializeField] [Range(0, 1f)] public float volume;
}
