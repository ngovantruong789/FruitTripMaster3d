using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadScene : BaseButton
{
    [SerializeField] protected string scene;

    protected override void OnClick()
    {
        if(scene != "")
            SceneManager.LoadScene(scene);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1f;
    }
}
