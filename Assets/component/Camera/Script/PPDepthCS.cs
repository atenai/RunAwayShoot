using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPDepthCS : MonoBehaviour
{
    public Material EffectMaterial;

    private void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode = cam.depthTextureMode | DepthTextureMode.Depth;
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (EffectMaterial)
        {
            Graphics.Blit(src, dest, EffectMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
