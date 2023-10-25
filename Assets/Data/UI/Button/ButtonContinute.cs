using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinute : BaseButton
{
    protected override void OnClick()
    {
        Time.timeScale = 1;
        ButtonPause buttonPause = transform.GetComponentInParent<ButtonPause>();
        buttonPause.SetPanelPause(false);
    }
}
