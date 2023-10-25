using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEffect : TruongMonoBehaviour
{
    [SerializeField] protected float timer;
    [SerializeField] protected float timeLimit;

    [SerializeField] protected float minScale;
    [SerializeField] protected float maxScale;
    [SerializeField] protected float addScaleX;
    [SerializeField] protected float addScaleY;
    [SerializeField] protected bool isScale;

    protected void FixedUpdate()
    {
        CheckLimitScale();
        ChangeScale();
    }

    protected void ChangeScale()
    {
        timer += Time.fixedDeltaTime;
        if (timer < timeLimit) return;
        timer = 0;

        Vector3 scale = gameObject.transform.localScale;

        if (isScale)
            gameObject.transform.localScale = new Vector3(scale.x + addScaleX, scale.y + addScaleY, scale.z);
        else
            gameObject.transform.localScale = new Vector3(scale.x - addScaleX, scale.y - addScaleY, scale.z);
    }

    protected void CheckLimitScale()
    {
        Vector3 scale = gameObject.transform.localScale;
        if (scale.x >= maxScale) isScale = false;
        else if(scale.x <= minScale) isScale = true;
    }
}
