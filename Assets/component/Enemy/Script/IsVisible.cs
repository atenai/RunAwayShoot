using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{

    private Renderer _Renderer;

    // Start is called before the first frame update
    void Start()
    {
        _Renderer = this.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
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
