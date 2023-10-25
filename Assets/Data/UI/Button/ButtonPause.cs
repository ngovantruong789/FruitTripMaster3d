using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : BaseButton
{
    [SerializeField] protected Transform panelPause;
    [SerializeField] protected bool isPause;
    public bool IsPause => isPause;

    protected override void Start()
    {
        base.Start();
        SetPanelPause(false);
        Time.timeScale = 1;
    }

    protected override void LoadData()
    {
        base.LoadData();
        panelPause = transform.Find("PanelPause");
    }

    protected override void OnClick()
    {
        SetPanelPause(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void SetPanelPause(bool isEnable)
    {
        panelPause.gameObject.SetActive(isEnable);
        if (!isEnable) isPause = false;
    }
}
