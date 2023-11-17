using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
    Renderer _Renderer;

    void Start()
    {
        _Renderer = this.gameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        if (Is_Visible())
        {
            //Debug.Log("表示中");
        }
        else
        {
            //Debug.Log("非表示中");
        }
    }

    public bool Is_Visible()
    {
        return _Renderer.isVisible;
    }
}
