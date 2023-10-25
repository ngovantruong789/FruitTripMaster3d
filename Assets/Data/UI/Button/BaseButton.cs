using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : TruongMonoBehaviour
{
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        AddOnClickEvent();
    }

    protected override void LoadData()
    {
        base.LoadData();
        button = GetComponent<Button>();
    }

    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();
}
