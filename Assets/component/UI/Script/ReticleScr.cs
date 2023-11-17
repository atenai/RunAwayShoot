using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScr : MonoBehaviour
{
    float mReticleScale = 0;

    void LateUpdate()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(mReticleScale * 2 + 2, mReticleScale * 2 + 2);
    }

    public void setReticleSize(float _scale)
    {
        mReticleScale = _scale;
    }
}
