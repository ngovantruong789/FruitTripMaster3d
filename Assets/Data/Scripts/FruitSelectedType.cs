using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSelectedType : TruongMonoBehaviour
{
    public string fruitName;
    public ParticleSystem particleSystem;

    protected override void LoadData()
    {
        base.LoadData();
        if(particleSystem == null) particleSystem = transform.GetComponentInChildren<ParticleSystem>();
    }
}
