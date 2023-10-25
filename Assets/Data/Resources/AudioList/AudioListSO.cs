using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/AudioList", fileName = "AudioList")]
public class AudioListSO : ScriptableObject
{
    public List<AudioType> audioTypes;
    public AudioClip musicBackground;
}
