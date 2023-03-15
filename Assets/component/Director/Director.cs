using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour
{

    public int area_Num = 0;//エリアカウント

    //フェード
    public float fadeInSpeed = 0.05f; //フェードインのスピード
    public float fadeOutSpeed = 0.05f; //フェードアウトのスピード
    private Color Area1DirectortextColor;//Area1ディレクターテキストのカラー変数
    private Color Area2DirectortextColor;//Area2ディレクターテキストのカラー変数
    private Color Area3DirectortextColor;//Area3ディレクターテキストのカラー変数
    private Color Area4DirectortextColor;
    private Color Area5DirectortextColor;//Area5ディレクターテキストのカラー変数
    private Color Area6DirectortextColor;
    private Color ContenttextColor;//コンテントテキストのカラー変数

    private Color Area1MissionSuccesstextColor;//ミッションテキストのカラー変数
    private Color Area2MissionSuccesstextColor;//ミッションテキストのカラー変数
    private Color Area3MissionSuccesstextColor;//ミッションテキストのカラー変数
    private Color Area4MissionSuccesstextColor;//ミッションテキストのカラー変数
    private Color Area5MissionSuccesstextColor;//ミッションテキストのカラー変数
    private Color Area6MissionSuccesstextColor;//ミッションテキストのカラー変数
    private Color Area2MissionFailuretextColor;//ミッションテキストのカラー変数
    private Color Area4MissionFailuretextColor;//ミッションテキストのカラー変数
    private Color Area5MissionFailuretextColor;//ミッションテキストのカラー変数
    private Color AllMissionSuccesstextColor;//Allミッションテキストのカラー変数

    bool b_Area1Fade = false;
    bool b_Area2MissionSuccessFade = false;
    bool b_Area2MissionFailureFade = false;
    bool b_Area3Fade = false;
    bool b_Area4MissionSuccessFade = false;
    bool b_Area4MissionFailureFade = false;
    bool b_Area5MissionSuccessFade = false;
    bool b_Area5MissionFailureFade = false;
    bool b_Area6Fade = false;
    bool b_AreaAllFade = false;


    //エリア１用変数
    static public int enemyDestroyNum = 0; //倒した敵の数
    public bool b_Area1 = false;
    static bool Enemy1 = false;
    static bool Enemy2 = false;
    static bool Enemy3 = false;
    static bool Enemy4 = false;
    static bool Enemy5 = false;
    static bool Enemy6 = false;
    static bool Enemy7 = false;
    static bool Enemy8 = false;
    public bool b_GOAL1 = false;

    //エリア２用変数
    static public bool enemyFound = false;//敵に見つかったかどうか？
    public bool b_Area2 = true;
    public bool b_FoundFalseGOAL = false;
    static public bool b_Area2if = false;
    public bool b_GOAL2 = false;

    //エリア３用変数
    public bool b_Area3 = true;
    static public bool b_Area3if = false;
    static public bool b_EnemyDrumsDestroy = false;
    public bool b_GOAL3 = false;

    //エリア４用変数
    public bool b_Area4 = true;
    public static float time = 50.0f;
    int t;
    bool b_TimeOver = false;
    public bool b_TimeOverFalseGOAL = false;
    public bool b_GOAL4 = false;

    //エリア５用変数
    public bool b_Area5 = true;
    static public bool b_Area5if = false;
    static public bool b_PlayerDamege = false;
    public bool b_DamegeFalseGOAL = false;
    public bool b_GOAL5 = false;

    //エリア６用変数
    public bool b_Area6 = true;
    bool nood1 = false;
    bool nood2 = false;
    bool nood3 = false;
    bool nood4 = false;
    bool nood5 = false;
    int noodNum = 0;
    public bool b_GOAL6 = false;

    //全エリアのAI監督の要望達成変数
    bool b_All_Area1 = false;
    bool b_All_Area2 = false;
    bool b_All_Area3 = false;
    bool b_All_Area4 = false;
    bool b_All_Area5 = false;
    bool b_All_Area6 = false;
    public bool b_AreaAll = true;

    Text direct_text;
    Text content_text;
    Text MissionSuccess_text;
    Text Table1_text;
    Text Table2_text;
    Text Table3_text;
    Text Table4_text;
    Text Table5_text;
    Text Table6_text;
    Text Table7_text;
    Text Table8_text;
    Text AllMissionSuccess_text;

    //サウンド
    public AudioClip soundMissionSuccess;
    public AudioClip soundMissionFailure;
    bool b_SE_Failure_Area2 = true;
    bool b_SE_Failure_Area4 = true;
    bool b_SE_Failure_Area5 = true;
    public AudioClip soundAllMissionSuccess;
    public AudioClip soundMissionStart;
    bool b_SE_Start_Area1 = true;
    bool b_SE_Start_Area2 = true;
    bool b_SE_Start_Area3 = true;
    bool b_SE_Start_Area4 = true;
    bool b_SE_Start_Area5 = true;
    bool b_SE_Start_Area6 = true;
    AudioSource audioSource;

    //　他スクリプト変数　取得用

    player player;

    //エリアディレクターテクスチャ
    // コンポーネントの取得
    [SerializeField] private Image ImageArea1Director_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea2Director_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea3Director_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea4Director_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea5Director_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea6Director_component;

    //エリアテクスチャ
    // コンポーネントの取得
    [SerializeField] private Image ImageArea1_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea2_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea3_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea4_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea5_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea6_component;

    //ミッションサクセステクスチャ
    // コンポーネントの取得
    [SerializeField] private Image ImageArea1MissionSuccess_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea2MissionSuccess_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea3MissionSuccess_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea4MissionSuccess_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea5MissionSuccess_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea6MissionSuccess_component;

    //ミッションフェイルテクスチャ
    // コンポーネントの取得
    [SerializeField] private Image ImageArea2MissionFailure_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea4MissionFailure_component;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea5MissionFailure_component;

    //オールミッションサクセステクスチャ
    // コンポーネントの取得
    [SerializeField] private Image ImageAllMissionSuccess_component;


    void Awake()
    {
        //Textコンポーネント取得
        direct_text = GameObject.Find("Director").GetComponent<Text>();
        //direct_text.text = "エリア0";
        direct_text.text = "";
        //テキストカラー初期化
        direct_text.color = new Color(255.0f, 255.0f, 255.0f);
        //フェードイン
        //称号のカラーを取得してアルファを０に初期化
        //エリア1
        Area1DirectortextColor = direct_text.color;
        Area1DirectortextColor.a = 0;
        direct_text.color = Area1DirectortextColor;
        //エリア2
        Area2DirectortextColor = direct_text.color;
        Area2DirectortextColor.a = 0;
        direct_text.color = Area2DirectortextColor;
        //エリア3
        Area3DirectortextColor = direct_text.color;
        Area3DirectortextColor.a = 0;
        direct_text.color = Area3DirectortextColor;
        //エリア4
        Area4DirectortextColor = direct_text.color;
        Area4DirectortextColor.a = 0;
        direct_text.color = Area4DirectortextColor;
        //エリア5
        Area5DirectortextColor = direct_text.color;
        Area5DirectortextColor.a = 0;
        direct_text.color = Area5DirectortextColor;
        //エリア6
        Area6DirectortextColor = direct_text.color;
        Area6DirectortextColor.a = 0;
        direct_text.color = Area6DirectortextColor;

        //Textコンポーネント取得
        content_text = GameObject.Find("Content").GetComponent<Text>();
        //content_text.text = "内容";
        content_text.text = "";
        //テキストカラー初期化
        //content_text.color = new Color(197.0f, 29.0f, 84.0f);
        //フェードイン
        //称号のカラーを取得してアルファを０に初期化
        ContenttextColor = content_text.color;
        ContenttextColor.a = 0;
        content_text.color = ContenttextColor;

        //Textコンポーネント取得
        MissionSuccess_text = GameObject.Find("Mission Success").GetComponent<Text>();
        MissionSuccess_text.text = "";
        //テキストカラー初期化
        MissionSuccess_text.color = new Color(255.0f, 255.0f, 255.0f);
        //フェードイン
        //称号のカラーを取得してアルファを０に初期化
        Area1MissionSuccesstextColor = MissionSuccess_text.color;
        Area1MissionSuccesstextColor.a = 0;
        MissionSuccess_text.color = Area1MissionSuccesstextColor;
        //称号のカラーを取得してアルファを０に初期化
        Area2MissionSuccesstextColor = MissionSuccess_text.color;
        Area2MissionSuccesstextColor.a = 0;
        MissionSuccess_text.color = Area2MissionSuccesstextColor;
        //称号のカラーを取得してアルファを０に初期化
        Area3MissionSuccesstextColor = MissionSuccess_text.color;
        Area3MissionSuccesstextColor.a = 0;
        MissionSuccess_text.color = Area3MissionSuccesstextColor;
        //称号のカラーを取得してアルファを０に初期化
        Area4MissionSuccesstextColor = MissionSuccess_text.color;
        Area4MissionSuccesstextColor.a = 0;
        MissionSuccess_text.color = Area4MissionSuccesstextColor;
        //称号のカラーを取得してアルファを０に初期化
        Area5MissionSuccesstextColor = MissionSuccess_text.color;
        Area5MissionSuccesstextColor.a = 0;
        MissionSuccess_text.color = Area5MissionSuccesstextColor;
        //称号のカラーを取得してアルファを０に初期化
        Area6MissionSuccesstextColor = MissionSuccess_text.color;
        Area6MissionSuccesstextColor.a = 0;
        MissionSuccess_text.color = Area6MissionSuccesstextColor;

        //称号のカラーを取得してアルファを０に初期化
        Area2MissionFailuretextColor = MissionSuccess_text.color;
        Area2MissionFailuretextColor.a = 0;
        //称号のカラーを取得してアルファを０に初期化
        Area4MissionFailuretextColor = MissionSuccess_text.color;
        Area4MissionFailuretextColor.a = 0;
        //称号のカラーを取得してアルファを０に初期化
        Area5MissionFailuretextColor = MissionSuccess_text.color;
        Area5MissionFailuretextColor.a = 0;

        //Textコンポーネント取得
        Table1_text = GameObject.Find("Table1").GetComponent<Text>();
        Table1_text.text = "";

        Table2_text = GameObject.Find("Table2").GetComponent<Text>();
        Table2_text.text = "";

        Table3_text = GameObject.Find("Table3").GetComponent<Text>();
        Table3_text.text = "";

        Table4_text = GameObject.Find("Table4").GetComponent<Text>();
        Table4_text.text = "";

        Table5_text = GameObject.Find("Table5").GetComponent<Text>();
        Table5_text.text = "";

        Table6_text = GameObject.Find("Table6").GetComponent<Text>();
        Table6_text.text = "";

        Table7_text = GameObject.Find("Table7").GetComponent<Text>();
        Table7_text.text = "";

        Table8_text = GameObject.Find("Table8").GetComponent<Text>();
        Table8_text.text = "";

        AllMissionSuccess_text = GameObject.Find("All Mission Success").GetComponent<Text>();
        AllMissionSuccess_text.text = "";

        //称号のカラーを取得してアルファを０に初期化
        AllMissionSuccesstextColor = AllMissionSuccess_text.color;
        AllMissionSuccesstextColor.a = 0;
        AllMissionSuccess_text.color = AllMissionSuccesstextColor;

        //プレイヤー取得
        player = GameObject.Find("Player").GetComponent<player>();

        area_Num = 0;//エリアカウント

        b_GOAL1 = false;
        b_GOAL2 = false;
        b_GOAL3 = false;
        b_GOAL4 = false;
        b_GOAL5 = false;
        b_GOAL6 = false;

        b_Area1Fade = false;
        b_Area2MissionSuccessFade = false;
        b_Area2MissionFailureFade = false;
        b_Area3Fade = false;
        b_Area4MissionSuccessFade = false;
        b_Area4MissionFailureFade = false;
        b_Area5MissionSuccessFade = false;
        b_Area5MissionFailureFade = false;
        b_Area6Fade = false;

        b_AreaAllFade = false;

        //エリア１用変数初期化
        enemyDestroyNum = 0; //倒した敵の数
        b_Area1 = false;
        Enemy1 = false;
        Enemy2 = false;
        Enemy3 = false;
        Enemy4 = false;
        Enemy5 = false;
        Enemy6 = false;
        Enemy7 = false;
        Enemy8 = false;

        //エリア２用変数初期化
        enemyFound = false;//敵に見つかったかどうか？
        b_Area2 = true;
        b_FoundFalseGOAL = false;
        b_Area2if = false;

        //エリア３用変数初期化
        b_Area3 = true;
        b_Area3if = false;
        b_EnemyDrumsDestroy = false;

        //エリア４用変数初期化
        b_Area4 = true;
        time = 50.0f;
        t = 0;
        b_TimeOver = false;
        b_TimeOverFalseGOAL = false;

        //エリア５用変数初期化
        b_Area5 = true;
        b_Area5if = false;
        b_PlayerDamege = false;
        b_DamegeFalseGOAL = false;

        //エリア６用変数初期化
        b_Area6 = true;
        nood1 = false;
        nood2 = false;
        nood3 = false;
        nood4 = false;
        nood5 = false;
        noodNum = 0;

        //全エリアのAI監督の要望達成変数
        b_All_Area1 = false;
        b_All_Area2 = false;
        b_All_Area3 = false;
        b_All_Area4 = false;
        b_All_Area5 = false;
        b_All_Area6 = false;
        b_AreaAll = true;

        //Componentを取得
        audioSource = GetComponent<AudioSource>();
        b_SE_Failure_Area2 = true;
        b_SE_Failure_Area4 = true;
        b_SE_Failure_Area5 = true;
        b_SE_Start_Area1 = true;
        b_SE_Start_Area2 = true;
        b_SE_Start_Area3 = true;
        b_SE_Start_Area4 = true;
        b_SE_Start_Area5 = true;
        b_SE_Start_Area6 = true;


        //ディレクターテクスチャ
        //オブジェクト名と色名の配列
        string[] directorNames = { "ImageArea1Director", "ImageArea2Director", "ImageArea3Director", "ImageArea4Director", "ImageArea5Director", "ImageArea6Director" };
        //エリアテクスチャ
        //オブジェクト名と色名の配列
        string[] imageNames = { "ImageArea1", "ImageArea2", "ImageArea3", "ImageArea4", "ImageArea5", "ImageArea6" };
        //ミッションサクセステクスチャ
        //オブジェクト名と色名の配列
        string[] successNames = { "ImageArea1MissionSuccess", "ImageArea2MissionSuccess", "ImageArea3MissionSuccess", "ImageArea4MissionSuccess", "ImageArea5MissionSuccess", "ImageArea6MissionSuccess" };
        //ミッションフェイルテクスチャ
        //オブジェクト名と色名の配列
        string[] failureNames = { "ImageArea2MissionFailure", "ImageArea4MissionFailure", "ImageArea5MissionFailure" };
        //オールサクセステクスチャ
        //オブジェクト名と色名の配列
        string[] allSuccessNames = { "ImageAllMissionSuccess" };

        Color[] colors = { Area1DirectortextColor, Area2DirectortextColor, Area3DirectortextColor, Area4DirectortextColor, Area5DirectortextColor, Area6DirectortextColor };

        //画像の透明度を変える関数
        void ChangeAlpha(string name, Color color)
        {
            // オブジェクトの取得
            GameObject imageObject = GameObject.Find(name);
            // コンポーネントの取得
            Image imageComponent = imageObject.GetComponent<Image>();
            // 画像の透明度を変える
            imageComponent.color = color;
        }

        //配列から順番にオブジェクト名と色名を取り出して関数に渡すループ文
        for (int i = 0; i < directorNames.Length; i++)
        {
            ChangeAlpha(directorNames[i], colors[i]);
        }

        //配列から順番にオブジェクト名と色名を取り出して関数に渡すループ文
        for (int i = 0; i < imageNames.Length; i++)
        {
            ChangeAlpha(imageNames[i], colors[i]);
        }

        //配列から順番にオブジェクト名と色名を取り出して関数に渡すループ文
        for (int i = 0; i < successNames.Length; i++)
        {
            ChangeAlpha(successNames[i], colors[i]);
        }

        //配列から順番にオブジェクト名と色名を取り出して関数に渡すループ文
        for (int i = 0; i < failureNames.Length; i++)
        {
            ChangeAlpha(failureNames[i], colors[i]);
        }

        //配列から順番にオブジェクト名と色名を取り出して関数に渡すループ文
        for (int i = 0; i < allSuccessNames.Length; i++)
        {
            ChangeAlpha(allSuccessNames[i], colors[i]);
        }
    }


    void Update()
    {
        if (area_Num == 1)
        {
            DirectorFadeIn(1);
            direct_text.text = "エリア1 \n 敵を全滅させろ！！";
            content_text.text = "";
            if (b_SE_Start_Area1 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area1 = false;
            }
            // 敵の状態を格納する配列
            bool[] enemies = new bool[8] { Enemy1, Enemy2, Enemy3, Enemy4, Enemy5, Enemy6, Enemy7, Enemy8 };
            // テキストを格納する配列
            Text[] tables = new Text[8] { Table1_text, Table2_text, Table3_text, Table4_text, Table5_text, Table6_text, Table7_text, Table8_text };
            // 配列の要素を順番にチェックする
            for (int i = 0; i < enemies.Length; i++)
            {
                // もし敵が倒されていたら
                if (enemies[i] == true)
                {
                    // テキストを「敵〇〇を破壊」とする
                    tables[i].text = "敵" + (i + 1) + "を破壊";
                }
                else
                {
                    // テキストを「敵〇〇は生存中」とする
                    tables[i].text = "敵" + (i + 1) + "は生存中";
                }
            }
            if (b_Area1 == false && Enemy1 == true && Enemy2 == true && Enemy3 == true && Enemy4 == true && Enemy5 == true && Enemy6 == true && Enemy7 == true && Enemy8 == true)
            {
                Score.AddScore(2);
                MissionSuccess_text.color = new Color(197.0f, 29.0f, 84.0f);
                MissionSuccess_text.text = "Area1MissionSuccess";
                b_Area1Fade = true;
                audioSource.PlayOneShot(soundMissionSuccess);
                b_All_Area1 = true;
                b_Area1 = true;
            }
            if (b_Area1Fade == true)
            {
                MissionSuccessFadeIn(1);
            }
            else
            {
                MissionSuccessFadeOut(1);
            }
            if (b_GOAL1 == true)
            {
                DirectorFadeOut(1);
                content_text.text = "";
                Table1_text.text = "";
                Table2_text.text = "";
                Table3_text.text = "";
                Table4_text.text = "";
                Table5_text.text = "";
                Table6_text.text = "";
                Table7_text.text = "";
                Table8_text.text = "";
            }
        }

        else if (area_Num == 2)
        {
            // エリア1のミッション成功テキストをフェードアウトする
            MissionSuccessFadeOut(1);

            // エリア2のディレクターテキストをフェードインする
            DirectorFadeIn(2);

            // ディレクターテキストの内容を設定する
            direct_text.text = "エリア2 \n 敵に見つからずに進め！！";

            // ミッション開始時にサウンドを再生する（一回だけ）
            if (b_SE_Start_Area2 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area2 = false;
            }

            // 敵に見つかったかどうかでテキストの内容を変える
            content_text.text = enemyFound ? "見つかった" : "見つかってない";

            // 敵に見つかった場合はミッション失敗とする
            if (enemyFound == true)
            {
                // ミッション失敗テキストの色と内容を設定する関数（前回の回答で定義）
                SetText(MissionSuccess_text, "Area2MissionFailure", 0.0f, 0.0f, 255.0f);

                b_Area2MissionFailureFade = true;

                // ミッション失敗時にサウンドを再生する（一回だけ）
                if (b_SE_Failure_Area2 == true)
                {
                    audioSource.PlayOneShot(soundMissionFailure);
                    b_SE_Failure_Area2 = false;
                }

                // ミッション失敗テキストをフェードインする
                MissionFailureFadeIn(2);

                // ここでミッション失敗時の処理を行う（例：ゲームオーバー画面へ遷移）

            }

            // 敵に見つからないでゴールした場合はミッション成功とする
            else if (enemyFound == false && b_Area2 == true && b_FoundFalseGOAL == true)
            {
                // スコアを加算する
                Score.AddScore(2);

                b_Area2 = false;

                // ミッション成功テキストの色と内容を設定する関数（前回の回答で定義）
                SetText(MissionSuccess_text, "Area2MissionSuccess", 197.0f, 29.0f, 84.0f);

                b_Area2MissionSuccessFade = true;

                audioSource.PlayOneShot(soundMissionSuccess);

                b_All_Area2 = true;

                // ミッション成功テキストをフェードインする
                MissionSuccessFadeIn(2);

                // ここでミッション成功時の処理を行う（例：次のエリアへ遷移）

            }
            else
            {
                MissionSuccessFadeOut(2);
                MissionFailureFadeOut(2);
            }

            if (b_GOAL2 == true)
            {
                DirectorFadeOut(2);

                content_text.text = "";
            }
        }

        else if (area_Num == 3)
        {
            // エリア2のミッション成功・失敗テキストをフェードアウトする
            MissionSuccessFadeOut(2);
            MissionFailureFadeOut(2);

            // エリア3のディレクターテキストをフェードインする
            DirectorFadeIn(3);

            // ディレクターテキストの内容を設定する
            direct_text.text = "エリア3 \n 爆発物を使って敵を倒せ！！";

            // ミッション開始時にサウンドを再生する（一回だけ）
            if (b_SE_Start_Area3 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area3 = false;
            }

            // 敵が爆発物で倒されたかどうかでテキストの内容を変える
            content_text.text = b_EnemyDrumsDestroy ? "爆発物で倒した" : "爆発物で倒してない";

            // 敵が爆発物で倒されてゴールした場合はミッション成功とする
            if (b_EnemyDrumsDestroy == true && b_Area3 == true)
            {
                // スコアを加算する
                Score.AddScore(2);

                b_Area3 = false;

                // ミッション成功テキストの色と内容を設定する関数（前回の回答で定義）
                SetText(MissionSuccess_text, "Area3MissionSuccess", 197.0f, 29.0f, 84.0f);

                b_Area3Fade = true;

                audioSource.PlayOneShot(soundMissionSuccess);

                b_All_Area3 = true;

                // ミッション成功テキストをフェードインする
                MissionSuccessFadeIn(3);

                // ここでミッション成功時の処理を行う（例：次のエリアへ遷移）

            }

            else
            {
                MissionSuccessFadeOut(3);
            }

            if (b_GOAL3 == true)
            {
                DirectorFadeOut(3);

                content_text.text = "";
            }
        }

        else if (area_Num == 4)
        {
            // エリア5のミッション成功・失敗テキストをフェードアウトする
            MissionSuccessFadeOut(5);
            MissionFailureFadeOut(4);

            // エリア6のディレクターテキストをフェードインする
            DirectorFadeIn(4);

            // 残り時間を減らして表示する
            time -= Time.deltaTime;
            t = Mathf.FloorToInt(time);
            direct_text.text = "エリア6 \n 制限時間内に駆け抜けろ！！";
            content_text.text = "残り時間 : " + t;

            // ミッション開始時にサウンドを再生する（一回だけ）
            if (b_SE_Start_Area4 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area4 = false;
            }

            // 時間切れになったらミッション失敗とする
            if (t <= 0)
            {
                b_TimeOver = true;
                Debug.Log("時間切れ");
                content_text.text = "時間切れ";

                // ミッション失敗テキストの色と内容を設定する関数（前回の回答で定義）
                SetText(MissionSuccess_text, "Area6MissionFailure", 0.0f, 0.0f, 255.0f);

                b_Area4MissionFailureFade = true;

                // ミッション失敗時にサウンドを再生する（一回だけ）
                if (b_SE_Failure_Area4 == true)
                {
                    audioSource.PlayOneShot(soundMissionFailure);
                    b_SE_Failure_Area4 = false;
                }
            }

            else
            {
                // 時間切れでなくてゴールした場合はミッション成功とする
                if (b_TimeOverFalseGOAL == true && b_Area4 == true)
                {
                    // スコアを加算する
                    Score.AddScore(2);

                    b_Area4 = false;

                    // ミッション成功テキストの色と内容を設定する関数（前回の回答で定義）
                    SetText(MissionSuccess_text, "Area6MissionSuccess", 197.0f, 29.0f, 84.0f);

                    b_Area4MissionSuccessFade = true;

                    audioSource.PlayOneShot(soundMissionSuccess);

                    b_All_Area4 = true;

                    // 全てのエリアが成功した場合は特別な処理を行う
                    if (b_All_Area1 == true && b_All_Area2 == true && b_All_Area3 == true && b_All_Area4 == true && b_All_Area5 == true && b_All_Area6 == true && b_AreaAll == true)
                    {
                        Score.AddScore(3);

                        AllMissionSuccess_text.text = "AllMissionSuccess";

                        b_AreaAllFade = true;

                        audioSource.PlayOneShot(soundAllMissionSuccess);

                        b_AreaAll = false;

                        // ここで全てのミッション成功時の処理を行う（例：ゲームクリア画面へ遷移）

                    }
                }
            }
        }


        else if (area_Num == 5)
        {
            // エリア6のミッション成功・失敗テキストをフェードアウトする
            MissionSuccessFadeOut(6);

            // エリア5のディレクターテキストをフェードインする
            DirectorFadeIn(5);

            b_Area5if = true;

            direct_text.text = "エリア5 \n ダメージを受けるな！！";

            // ミッション開始時にサウンドを再生する（一回だけ）
            if (b_SE_Start_Area5 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area5 = false;
            }

            // ダメージを受けたかどうかでテキストやミッション失敗処理を行う
            if (b_PlayerDamege == true)
            {
                content_text.text = "ダメージを受けた";

                // ミッション失敗テキストの色と内容を設定する関数（前回の回答で定義）
                SetText(MissionSuccess_text, "Area5MissionFailure", 0.0f, 0.0f, 255.0f);

                b_Area5MissionFailureFade = true;

                // ミッション失敗時にサウンドを再生する（一回だけ）
                if (b_SE_Failure_Area5 == true)
                {
                    audioSource.PlayOneShot(soundMissionFailure);
                    b_SE_Failure_Area5 = false;
                }
            }
            else
            {
                content_text.text = "ダメージを受けていない";

                // ダメージを受けずにゴールした場合はミッション成功とする
                if (b_DamegeFalseGOAL == true && b_Area5 == true)
                {
                    // スコアを加算する
                    Score.AddScore(2);

                    b_Area5 = false;

                    // ミッション成功テキストの色と内容を設定する関数（前回の回答で定義）
                    SetText(MissionSuccess_text, "Area5MissionSuccess", 197.0f, 29.0f, 84.0f);

                    b_Area5MissionSuccessFade = true;

                    audioSource.PlayOneShot(soundMissionSuccess);

                    b_All_Area5 = true;
                }
            }

            // ミッション成功・失敗テキストのフェードイン・フェードアウト処理
            if (b_Area5MissionSuccessFade == true)
            {
                MissionSuccessFadeIn(4);
            }
            else if (b_Area4MissionFailureFade == true)
            {
                MissionFailureFadeIn(4);
            }
            else
            {
                MissionSuccessFadeOut(4);
                MissionFailureFadeOut(4);
            }

            // ゴールしたらディレクターテキストとコンテントテキストをフェードアウトする
            if (b_GOAL4 == true)
            {
                DirectorFadeOut(4);
                content_text.text = "";

                // ここでゴール時の処理を行う（例：次のエリアへ移動）

            }
        }

        else if (area_Num == 6)
        {
            MissionSuccessFadeOut(3);
            DirectorFadeIn(6);
            direct_text.text = "エリア4 \n オレンジカプセルを取れ！！";
            content_text.text = "";
            if (b_SE_Start_Area6 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area6 = false;
            }

            //カプセル１から５まで共通化したメソッド（仮）
            CheckCapsules(nood1, Table1_text, "カプセル１");
            CheckCapsules(nood2, Table2_text, "カプセル２");
            CheckCapsules(nood3, Table3_text, "カプセル３");
            CheckCapsules(nood4, Table4_text, "カプセル４");
            CheckCapsules(nood5, Table5_text, "カプセル５");

            Table6_text.text = "";
            Table7_text.text = "";
            Table8_text.text = "";
        }

        //追加したコード
        if (b_Area6Fade == true)
        {
            MissionSuccessFadeIn(6);
        }
        else
        {
            MissionSuccessFadeOut(6);
        }
        if (b_GOAL6 == true)
        {
            DirectorFadeOut(6);
            content_text.text = "";
            Table1_text.text = "";
            Table2_text.text = "";
            Table3_text.text = "";
            Table4_text.text = "";
            Table5_text.text = "";
        }

        if (Input.GetKey("joystick button 13"))
        {
            SceneManager.LoadScene("title");
        }
    }

    // テキストの色と内容を設定する関数
    void SetText(Text text, string content, float r, float g, float b)
    {
        // テキストの内容を設定する
        text.text = content;

        // テキストの色を設定する（RGB値は255で割る必要がある）
        text.color = new Color(r / 255.0f, g / 255.0f, b / 255.0f);
    }

    //共通化したメソッド（仮）の定義
    void CheckCapsules(bool nood, Text tableText, string capsuleName)
    {
        if (nood == true)
        {
            tableText.text = capsuleName + "発見";
        }
        else
        {
            tableText.text = capsuleName + "未発見";
        }
    }

    //敵全て倒したら(EnemyMove)
    static public void EnemyDestroy()
    {
        enemyDestroyNum = enemyDestroyNum + 1;
    }

    //敵に見つかったかどうか？
    static public void EnemyFound()
    {
        if (b_Area2if == true)
        {
            enemyFound = true;
        }
    }

    //敵をドラム缶・消火器で殺したら
    static public void EnemyDrumsDestroy()
    {
        if (b_Area3if == true)
        {
            b_EnemyDrumsDestroy = true;
        }
    }

    //プレイヤーがダメージを受けたら
    static public void PlayerDamege()
    {
        if (b_Area5if == true)
        {
            b_PlayerDamege = true;
        }
    }

    //ノード
    public void Addnood1()
    {
        nood1 = true;//nood1に当たった場合の処理
        noodNum++;
    }

    public void Addnood2()
    {
        nood2 = true;//nood2に当たった場合の処理
        noodNum++;
    }

    public void Addnood3()
    {
        nood3 = true;//nood3に当たった場合の処理
        noodNum++;
    }

    public void Addnood4()
    {
        nood4 = true;//nood4に当たった場合の処理
        noodNum++;
    }

    public void Addnood5()
    {
        nood5 = true;//nood5に当たった場合の処理
        noodNum++;
    }


    static public void EnemyDestroy1()
    {
        Enemy1 = true;
    }

    static public void EnemyDestroy2()
    {
        Enemy2 = true;
    }

    static public void EnemyDestroy3()
    {
        Enemy3 = true;
    }

    static public void EnemyDestroy4()
    {
        Enemy4 = true;
    }

    static public void EnemyDestroy5()
    {
        Enemy5 = true;
    }

    static public void EnemyDestroy6()
    {
        Enemy6 = true;
    }

    static public void EnemyDestroy7()
    {
        Enemy7 = true;
    }

    static public void EnemyDestroy8()
    {
        Enemy8 = true;
    }

    //リファクタリング
    void DirectorFadeIn(int areaNumber)
    {
        // テキストカラー
        var directColor = direct_text.color;
        var contentColor = content_text.color;
        // 画像コンポーネント
        var directorImage = ImageArea1Director_component;
        var areaImage = ImageArea1_component;

        // エリア番号に応じて画像コンポーネントを変更
        switch (areaNumber)
        {
            case 1:
                directorImage = ImageArea1Director_component;
                areaImage = ImageArea1_component;
                break;
            case 2:
                directorImage = ImageArea2Director_component;
                areaImage = ImageArea2_component;
                break;
            case 3:
                directorImage = ImageArea3Director_component;
                areaImage = ImageArea3_component;
                break;
            case 4:
                directorImage = ImageArea4Director_component;
                areaImage = ImageArea4_component;
                break;
            case 5:
                directorImage = ImageArea5Director_component;
                areaImage = ImageArea5_component;
                break;
            case 6:
                directorImage = ImageArea6Director_component;
                areaImage = ImageArea6_component;
                break;
            default:
                Debug.LogError("不正なエリア番号です");
                return;
        }

        // テキストカラーと画像カラーのアルファ値を増やす
        if (directColor.a <= 1)
        {
            directColor.a += fadeInSpeed;
            direct_text.color = directColor;

            // 画像の透明度を変える
            directorImage.color = directColor;
            areaImage.color = directColor;

            Debug.Log($"ディレクター{areaNumber}フェイドイン中だよ");
        }

        if (contentColor.a <= 1)
        {
            contentColor.a += fadeInSpeed;
            content_text.color = contentColor;

            Debug.Log($"コンテンツフェイドイン中だよ");
        }
    }

    //リファクタリング
    void MissionSuccessFadeIn(int areaNumber)
    {
        // テキストカラー
        var textColor = MissionSuccess_text.color;
        // 画像コンポーネント
        var imageComponent = ImageArea1MissionSuccess_component;

        // エリア番号に応じて画像コンポーネントを変更
        switch (areaNumber)
        {
            case 1:
                imageComponent = ImageArea1MissionSuccess_component;
                break;
            case 2:
                imageComponent = ImageArea2MissionSuccess_component;
                break;
            case 3:
                imageComponent = ImageArea3MissionSuccess_component;
                break;
            case 4:
                imageComponent = ImageArea4MissionSuccess_component;
                break;
            case 5:
                imageComponent = ImageArea5MissionSuccess_component;
                break;
            case 6:
                imageComponent = ImageArea6MissionSuccess_component;
                break;
            default:
                Debug.LogError("不正なエリア番号です");
                return;
        }

        // テキストカラーと画像カラーのアルファ値を増やす
        if (textColor.a <= 1)
        {
            textColor.a += fadeInSpeed;
            MissionSuccess_text.color = textColor;

            // 画像の透明度を変える
            imageComponent.color = textColor;

            Debug.Log($"ミッション成功{areaNumber}フェイドイン中だよ");
        }
    }
    void AllMissionSuccessFadeIn()
    {
        if (AllMissionSuccesstextColor.a <= 1)
        {
            AllMissionSuccesstextColor.a += fadeInSpeed;
            AllMissionSuccess_text.color = AllMissionSuccesstextColor;
            ImageAllMissionSuccess_component.color = AllMissionSuccesstextColor;
        }
    }

    //リファクタリング
    void MissionFailureFadeIn(int areaNumber)
    {
        // テキストカラー
        var textColor = MissionSuccess_text.color;
        // 画像コンポーネント
        var imageComponent = ImageArea2MissionFailure_component;

        // エリア番号に応じて画像コンポーネントを変更
        switch (areaNumber)
        {
            case 2:
                imageComponent = ImageArea2MissionFailure_component;
                break;
            case 4:
                imageComponent = ImageArea4MissionFailure_component;
                break;
            case 5:
                imageComponent = ImageArea5MissionFailure_component;
                break;
            default:
                Debug.LogError("不正なエリア番号です");
                return;
        }

        // テキストカラーと画像カラーのアルファ値を増やす
        if (textColor.a <= 1)
        {
            textColor.a += fadeInSpeed;
            MissionSuccess_text.color = textColor;

            // 画像の透明度を変える
            imageComponent.color = textColor;

            Debug.Log($"ミッション失敗{areaNumber}フェイドイン中だよ");
        }
    }

    //リファクタリング
    void DirectorFadeOut(int areaNumber)
    {
        // テキストカラー
        var textColor = direct_text.color;
        // 画像コンポーネント
        var imageComponent = ImageArea1Director_component;
        var imageAreaComponent = ImageArea1_component;

        // エリア番号に応じて画像コンポーネントを変更
        switch (areaNumber)
        {
            case 1:
                imageComponent = ImageArea1Director_component;
                imageAreaComponent = ImageArea1_component;
                break;
            case 2:
                imageComponent = ImageArea2Director_component;
                imageAreaComponent = ImageArea2_component;
                break;
            case 3:
                imageComponent = ImageArea3Director_component;
                imageAreaComponent = ImageArea3_component;
                break;
            case 4:
                imageComponent = ImageArea4Director_component;
                imageAreaComponent = ImageArea4_component;
                break;
            case 5:
                imageComponent = ImageArea5Director_component;
                imageAreaComponent = ImageArea5_component;
                break;
            case 6:
                imageComponent = ImageArea6Director_component;
                imageAreaComponent = ImageArea6_component;
                break;
            default:
                Debug.LogError("不正なエリア番号です");
                return;
        }

        // テキストカラーと画像カラーのアルファ値を0にする
        if (textColor.a >= 0)
        {
            textColor.a = 0;
            direct_text.color = textColor;

            // 画像の透明度を変える
            imageComponent.color = textColor;
            imageAreaComponent.color = textColor;

            Debug.Log($"ディレクター{areaNumber}フェイドアウト中だよ");
        }

        // コンテントテキストカラーのアルファ値を減らす
        if (ContenttextColor.a >= 0)
        {
            ContenttextColor.a -= fadeOutSpeed;
            content_text.color = ContenttextColor;
        }
    }

    //リファクタリング
    void MissionSuccessFadeOut(int areaNumber)
    {
        // テキストカラー
        var textColor = MissionSuccess_text.color;
        // 画像コンポーネント
        var imageComponent = ImageArea1MissionSuccess_component;

        // エリア番号に応じて画像コンポーネントを変更
        switch (areaNumber)
        {
            case 1:
                imageComponent = ImageArea1MissionSuccess_component;
                break;
            case 2:
                imageComponent = ImageArea2MissionSuccess_component;
                break;
            case 3:
                imageComponent = ImageArea3MissionSuccess_component;
                break;
            case 4:
                imageComponent = ImageArea4MissionSuccess_component;
                break;
            case 5:
                imageComponent = ImageArea5MissionSuccess_component;
                break;
            case 6:
                imageComponent = ImageArea6MissionSuccess_component;
                break;
            default:
                Debug.LogError("不正なエリア番号です");
                return;
        }

        // テキストカラーと画像カラーのアルファ値を0にする
        if (textColor.a >= 0)
        {
            textColor.a = 0;
            MissionSuccess_text.color = textColor;

            // 画像の透明度を変える
            imageComponent.color = textColor;
            Debug.Log($"ミッション{areaNumber}サクセスフェイドアウト中だよ");
        }
    }

    //リファクタリング
    void MissionFailureFadeOut(int areaNumber)
    {
        // テキストカラー
        var textColor = MissionSuccess_text.color;
        // 画像コンポーネント
        var imageComponent = ImageArea2MissionFailure_component;

        // エリア番号に応じて画像コンポーネントを変更
        switch (areaNumber)
        {
            case 2:
                imageComponent = ImageArea2MissionFailure_component;
                break;
            case 4:
                imageComponent = ImageArea4MissionFailure_component;
                break;
            case 5:
                imageComponent = ImageArea5MissionFailure_component;
                break;
            default:
                Debug.LogError("不正なエリア番号です");
                return;
        }

        // テキストカラーと画像カラーのアルファ値を0にする
        if (textColor.a >= 0)
        {
            textColor.a = 0;
            MissionSuccess_text.color = textColor;

            // 画像の透明度を変える
            imageComponent.color = textColor;
            //Debug.Log($"ミッション{areaNumber}フェイルフェードアウト中だよ");
        }
    }
}