using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//
//  Yamashita Shota
//  シーンLoad、フェード処理
//


public class SceneLoder : MonoBehaviour
{
    [SerializeField] private int mFPS;
    //フェード確認
    private bool mIsFade;
    //フェードの種類   false:In    true:Out
    private bool mInOut;
    //フェードのアルファ値保管
    private float mFadeAlfa;
    //　非同期動作で使用するAsyncOperation
    private AsyncOperation mAsync;
    //　シーンロード中に表示するUI画面
    [SerializeField] private GameObject mLoadUI;
    //　フェード用の背景
    [SerializeField] private GameObject mbackGround;
    [SerializeField] private Material mFadeMaterial;
    //フェードに用いる時間
    [SerializeField] private float mFadeSecond;

    //　読み込み率を表示するスライダー
    [SerializeField] private Slider mSlider;

    //次に読み込むシーン名
    private string mSceanName;

    void Start()
    {
        mFadeAlfa = 255;
        mInOut = false;
        mIsFade = true;
        mbackGround.gameObject.SetActive(true);
    }

    void Update()
    {
        Fade();
    }

    private void NextScene()
    {
        mbackGround.gameObject.SetActive(true);
        mIsFade = true;
        mInOut = true;
    }

    //Loading
    IEnumerator LoadData()
    {
        // シーンの読み込みをする
        mAsync = SceneManager.LoadSceneAsync(mSceanName);

        //　読み込みが終わるまで進捗状況をスライダーの値に反映させる
        while (!mAsync.isDone)
        {
            var progressVal = Mathf.Clamp01(mAsync.progress / 0.9f);
            mSlider.value = progressVal;
            yield return null;
        }
    }

    // ------------------------------------------------------------------
    //      フェード 
    private void Fade()
    {
        if (!mIsFade)
            return;
        // インアウトの判別
        if (!mInOut)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
    }

    private void FadeIn()
    {
        mFadeAlfa -= (255 / (mFPS * mFadeSecond));

        mFadeMaterial.color = new Color32(
            (byte)mFadeMaterial.color.r,
            (byte)mFadeMaterial.color.g,
            (byte)mFadeMaterial.color.b,
            (byte)(mFadeAlfa));

        if (mFadeAlfa <= 0)
        {
            mIsFade = false;
            mbackGround.gameObject.SetActive(false);
        }
    }

    private void FadeOut()
    {
        mFadeAlfa += (255 / (mFPS * mFadeSecond));

        mFadeMaterial.color = new Color32(
            (byte)mFadeMaterial.color.r,
            (byte)mFadeMaterial.color.g,
            (byte)mFadeMaterial.color.b,
            (byte)(mFadeAlfa));

        if (mFadeAlfa >= 255)
        {
            mIsFade = false;

            mLoadUI.SetActive(true);
            mSlider.gameObject.SetActive(true);
            //　コルーチンを開始
            StartCoroutine("LoadData");
        }
    }
    // ------------------------------------------------------------------

    // シーンをセット
    public void selectionScene(string _sceneName)
    {
        mSceanName = _sceneName;
        NextScene();
    }
}
