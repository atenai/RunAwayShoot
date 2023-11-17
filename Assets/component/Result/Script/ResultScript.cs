using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    [SerializeField] public float mFadeSpeed;   //フェード速度(デフォルト:30フレーム)
    private float mFadeSize;                    //１フレームのフェード量(デフォルト:100/30フレーム)
    private float mFadeAlfa;                    //１フレームのフェード量(デフォルト:255/30フレーム)

    private int i = 0;                          //カウンター
    private int MaxCnt = 0;
    private float alfa = 0;                     //α値
    public RectTransform[] StarRect;            //StarのRectTransformを格納(Imgaeの拡大縮小に使う)
    public Image[] StarImage;                   //StarのImgaeを格納(Imgaeフェード時に使う)
    //--------------------------------------
    public Text ReviewScore_Text;
    public Text Comment1_Text;
    public Text Comment2_Text;
    public Text Score_Text;
    //--------------------------------------
    public Image Poster_Image;
    //--------------------------------------
    private uint mScore;
    public static int MaxScore;
    private uint nModeCnt;
    private float fReviewScore;

    void Awake()
    {
        //RectTransform格納
        StarRect[0] = this.gameObject.transform.Find("Star1").GetComponent<RectTransform>();
        StarRect[1] = this.gameObject.transform.Find("Star2").GetComponent<RectTransform>();
        StarRect[2] = this.gameObject.transform.Find("Star3").GetComponent<RectTransform>();
        StarRect[3] = this.gameObject.transform.Find("Star4").GetComponent<RectTransform>();
        StarRect[4] = this.gameObject.transform.Find("Star5").GetComponent<RectTransform>();
        //Image格納
        StarImage[0] = this.gameObject.transform.Find("Star1").GetComponent<Image>();
        StarImage[1] = this.gameObject.transform.Find("Star2").GetComponent<Image>();
        StarImage[2] = this.gameObject.transform.Find("Star3").GetComponent<Image>();
        StarImage[3] = this.gameObject.transform.Find("Star4").GetComponent<Image>();
        StarImage[4] = this.gameObject.transform.Find("Star5").GetComponent<Image>();
        //Texture 初期化
        StarImage[0].sprite = StarImage[1].sprite = StarImage[2].sprite = StarImage[3].sprite = StarImage[4].sprite = this.gameObject.GetComponent<TextureManager>().Star;
        //α値を0に初期化
        StarImage[0].color = StarImage[1].color = StarImage[2].color = StarImage[3].color = StarImage[4].color = new Color(255, 255, 255, 0);
        //サイズを200*200に初期化
        StarRect[0].sizeDelta = StarRect[1].sizeDelta = StarRect[2].sizeDelta = StarRect[3].sizeDelta = StarRect[4].sizeDelta = new Vector2(200.0f, 200.0f);
        //フェードスピード初期化
        mFadeSpeed = 30;
        //フェード量初期化
        mFadeSize = 100 / mFadeSpeed;
        mFadeAlfa = 255 / mFadeSpeed;
        //--------------------------------------------------------------------
        ReviewScore_Text = this.gameObject.transform.Find("ReviewText").GetComponent<Text>();
        Score_Text = this.gameObject.transform.Find("ScoreText").GetComponent<Text>();
        Comment1_Text = this.gameObject.transform.Find("Comment1").GetComponent<Text>();
        Comment2_Text = this.gameObject.transform.Find("Comment2").GetComponent<Text>();
        Score_Text.text = null;
        //--------------------------------------------------------------------------------------------------
        mScore = 0;
        MaxScore = Score.GetScore();
        //MaxScore = 50000;

        if (MaxScore <= 0)
        {
            MaxScore = 0;
        }

        //Review Star Count
        nModeCnt = 0;
        MaxCnt = MaxScore / 10000;                  //10000点につき星1つ
        fReviewScore = (float)MaxScore / 10000;     //レビュースコア計算
        if (fReviewScore >= 5.0f)
        {
            fReviewScore = 5.0f;
        }
        //--------------------------------------------------------------------------------------------------
        if (MaxScore % 10000 >= 5000 & MaxCnt < 5)                    //MaxScore/10000点の余りが5000点以上ある場合、星表示数+1。最後に表示する星のtextureをStar_Halfに変更
        {
            StarImage[MaxCnt].sprite = null;
            StarImage[MaxCnt].sprite = this.gameObject.GetComponent<TextureManager>().Star_Half;
            MaxCnt++;
        }
        if (MaxCnt >= 5)
        {
            MaxCnt = 5;
        }

        //--------------------------------------------------------------------------------------------------------
        //ポスター設定
        //--------------------------------------------------------------------------------------------------------
        Poster_Image = this.gameObject.transform.Find("PosterImage").GetComponent<Image>();

        if (MaxCnt >= 0 && MaxCnt < 2)
        {
            Poster_Image.sprite = this.gameObject.GetComponent<TextureManager>().m_PosterSprite[0];
        }
        if (MaxCnt >= 2 && MaxCnt < 3)
        {
            Poster_Image.sprite = this.gameObject.GetComponent<TextureManager>().m_PosterSprite[1];
        }
        if (MaxCnt >= 3 && MaxCnt < 4)
        {
            Poster_Image.sprite = this.gameObject.GetComponent<TextureManager>().m_PosterSprite[2];
        }
        if (MaxCnt >= 4)
        {
            Poster_Image.sprite = this.gameObject.GetComponent<TextureManager>().m_PosterSprite[3];
        }
    }

    void Update()
    {
        if (nModeCnt == 0)  //星表示フェーズ
        {
            Step1();
        }
        if (nModeCnt == 1)  //スコア表示フェーズ
        {
            Step2();
        }
        if (nModeCnt == 2)  //Reviewフェーズ
        {
            Step3();
        }
        if (nModeCnt == 3)  //Comment
        {
            Step4();
        }
        if (nModeCnt == 4)
        {
            FinalStep();
        }
    }

    void Step1()//Star
    {
        if (i == 0 && i < MaxCnt)
        {
            StarRect[0].sizeDelta = new Vector2(StarRect[0].sizeDelta.x - mFadeSize, StarRect[0].sizeDelta.y - mFadeSize);
            StarImage[0].color = new Color(255 / 255, 255 / 255, 255 / 255, alfa / 255);
            alfa += mFadeAlfa;
            if (StarRect[0].sizeDelta.x <= 100)
            {
                StarRect[0].sizeDelta = new Vector2(100.0f, 100.0f);
                StarImage[0].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
                i++;
                alfa = 0;
            }
        }
        if (i == 1 && i < MaxCnt)
        {
            StarRect[1].sizeDelta = new Vector2(StarRect[1].sizeDelta.x - mFadeSize, StarRect[1].sizeDelta.y - mFadeSize);
            StarImage[1].color = new Color(255 / 255, 255 / 255, 255 / 255, alfa / 255);
            alfa += mFadeAlfa;
            if (StarRect[1].sizeDelta.x <= 100)
            {
                StarRect[1].sizeDelta = new Vector2(100.0f, 100.0f);
                StarImage[1].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
                i++;
                alfa = 0;
            }
        }
        if (i == 2 && i < MaxCnt)
        {
            StarRect[2].sizeDelta = new Vector2(StarRect[2].sizeDelta.x - mFadeSize, StarRect[2].sizeDelta.y - mFadeSize);
            StarImage[2].color = new Color(255 / 255, 255 / 255, 255 / 255, alfa / 255);
            alfa += mFadeAlfa;
            if (StarRect[2].sizeDelta.x <= 100)
            {
                StarRect[2].sizeDelta = new Vector2(100.0f, 100.0f);
                StarImage[2].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
                i++;
                alfa = 0;
            }
        }
        if (i == 3 && i < MaxCnt)
        {
            StarRect[3].sizeDelta = new Vector2(StarRect[3].sizeDelta.x - mFadeSize, StarRect[3].sizeDelta.y - mFadeSize);
            StarImage[3].color = new Color(255 / 255, 255 / 255, 255 / 255, alfa / 255);
            alfa += mFadeAlfa;
            if (StarRect[3].sizeDelta.x <= 100)
            {
                StarRect[3].sizeDelta = new Vector2(100.0f, 100.0f);
                StarImage[3].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
                i++;
                alfa = 0;
            }
        }
        if (i == 4 && i < MaxCnt)
        {
            StarRect[4].sizeDelta = new Vector2(StarRect[4].sizeDelta.x - mFadeSize, StarRect[4].sizeDelta.y - mFadeSize);
            StarImage[4].color = new Color(255 / 255, 255 / 255, 255 / 255, alfa / 255);
            alfa += mFadeAlfa;
            if (StarRect[4].sizeDelta.x <= 100)
            {
                StarRect[4].sizeDelta = new Vector2(100.0f, 100.0f);
                StarImage[4].color = new Color(255 / 255, 255 / 255, 255 / 255, 255 / 255);
                i++;
                alfa = 0;

            }
        }
        if (i == MaxCnt)
        {
            nModeCnt++;
        }
    }

    void Step2()//Score
    {

        Score_Text.text = "Score :" + mScore;
        if (mScore >= MaxScore)
        {
            mScore = (uint)MaxScore;
            Score_Text.text = "Score :" + mScore;
            nModeCnt++;

        }

        mScore += 200;
    }

    void Step3()//Review Score
    {
        ReviewScore_Text.text = " " + fReviewScore;
        if (fReviewScore >= 5.0f)
        {
            ReviewScore_Text.text = "5.0";
        }
        nModeCnt++;
    }

    void Step4()//Comment
    {
        int Comment_Type = (int)fReviewScore;

        if (Comment_Type <= 0)          //最低評価
        {
            Comment1_Text.text = "ゴミ映画";
            Comment2_Text.text = "撮影代金返せ！";
        }
        if (Comment_Type == 1)
        {
            Comment1_Text.text = "紙映画";
            Comment2_Text.text = "紙見たいに薄っぺらいな！";
        }
        if (Comment_Type == 2)
        {
            Comment1_Text.text = "二流映画";
            Comment2_Text.text = "もう少し頑張ろう！";
        }
        if (Comment_Type == 3)
        {
            Comment1_Text.text = "普通映画";
            Comment2_Text.text = "名作映画まであともう一歩！";
        }
        if (Comment_Type == 4)
        {
            Comment1_Text.text = "名作映画";
            Comment2_Text.text = "この映画は人気がでる！！";
        }
        if (Comment_Type == 5)          //最高評価
        {
            Comment1_Text.text = "神映画";
            Comment2_Text.text = "歴史に残る傑作だ！！";
        }
        nModeCnt++;
    }

    void FinalStep()
    {
        if (Input.anyKeyDown || Input.GetButtonDown("PS4 Square") || Input.GetButtonDown("PS4 Circle") || Input.GetButtonDown("PS4 Cross"))
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("title");
            }
        }
    }
}
