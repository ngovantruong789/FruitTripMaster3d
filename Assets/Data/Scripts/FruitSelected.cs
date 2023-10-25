using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FruitSelected : TruongMonoBehaviour
{
    [SerializeField] protected SpawnFruitSelected spawnFruitPick;
    protected override void Start()
    {
        base.Start();
        if (spawnFruitPick == null) spawnFruitPick = FindObjectOfType<SpawnFruitSelected>();
    }

    public virtual void OnMouseDown()
    {
        bool isLose = spawnFruitPick.IsLose;
        bool isPause = FindObjectOfType<ButtonPause>().IsPause;
        if (isLose) return;
        if (isPause) return;

        spawnFruitPick.SpawnFruit(transform.name);
        SoundManager.Instance.PlayAudioClip("PickEffect");
        Destroy(gameObject);
    }
}
