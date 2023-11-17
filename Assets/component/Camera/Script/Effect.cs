using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------------
//  ポストエフェクト
//  ShotaYamasita


public class Effect : MonoBehaviour
{
    //ブラー用マテリアル情報
    public Material mMonoToonMat;

    //デフォルト
    private Material mDefMat;

    //使うポストエフェクトの種類列挙型
    enum PostEffectNum
    {
        Default = 0,        //何もしない
        MonoToon,           //白黒化
        GaussianBlur,       //全体ブラー

        Max
    }

    private PostEffectNum mType = 0;

    private void Update()
    {
        //キー入力によるシェーダの切り替え
        switchType();
        //下限上限の制限
        checkValue();
    }

    //ポストエフェクト処理
    void OnRenderImage(RenderTexture _source, RenderTexture _destination)
    {

        switch (mType)
        {
            case PostEffectNum.Default:
                defaltePostEffect(_source, _destination);
                break;

            case PostEffectNum.MonoToon:
                monoToonRender(_source, _destination);
                break;

            case PostEffectNum.GaussianBlur:
                gaussianBlur(_source, _destination);
                break;

            default:
                defaltePostEffect(_source, _destination);
                break;

        }
    }

    private void switchType()
    {
        //シェーダ切替入力検知
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            mType += 1;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            mType -= 1;
        }
    }

    private void checkValue()
    {
        //上限下限検知
        if (mType < 0)
        {
            mType = PostEffectNum.Max - 1;
        }
        else if (mType >= PostEffectNum.Max)
        {
            mType = PostEffectNum.Default;
        }
    }

    private void defaltePostEffect(RenderTexture _source, RenderTexture _destination)
    { Graphics.Blit(_source, _destination); }

    private void monoToonRender(RenderTexture _source, RenderTexture _destination)
    { Graphics.Blit(_source, _destination, mMonoToonMat); }

    private void gaussianBlur(RenderTexture _source, RenderTexture _destination)
    {

    }
}
