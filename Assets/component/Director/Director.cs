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
    // オブジェクトの取得
    GameObject ImageArea1Director_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea1Director_component;
    // オブジェクトの取得
    GameObject ImageArea2Director_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea2Director_component;
    // オブジェクトの取得
    GameObject ImageArea3Director_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea3Director_component;
    // オブジェクトの取得
    GameObject ImageArea4Director_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea4Director_component;
    // オブジェクトの取得
    GameObject ImageArea5Director_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea5Director_component;
    // オブジェクトの取得
    GameObject ImageArea6Director_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea6Director_component;

    //エリアテクスチャ
    // オブジェクトの取得
    GameObject ImageArea1_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea1_component;
    // オブジェクトの取得
    GameObject ImageArea2_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea2_component;
    // オブジェクトの取得
    GameObject ImageArea3_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea3_component;
    // オブジェクトの取得
    GameObject ImageArea4_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea4_component;
    // オブジェクトの取得
    GameObject ImageArea5_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea5_component;
    // オブジェクトの取得
    GameObject ImageArea6_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea6_component;

    //ミッションサクセステクスチャ
    // オブジェクトの取得
    GameObject ImageArea1MissionSuccess_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea1MissionSuccess_component;
    // オブジェクトの取得
    GameObject ImageArea2MissionSuccess_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea2MissionSuccess_component;
    // オブジェクトの取得
    GameObject ImageArea3MissionSuccess_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea3MissionSuccess_component;
    // オブジェクトの取得
    GameObject ImageArea4MissionSuccess_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea4MissionSuccess_component;
    // オブジェクトの取得
    GameObject ImageArea5MissionSuccess_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea5MissionSuccess_component;
    // オブジェクトの取得
    GameObject ImageArea6MissionSuccess_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea6MissionSuccess_component;

    //ミッションフェイルテクスチャ
    // オブジェクトの取得
    GameObject ImageArea2MissionFailure_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea2MissionFailure_component;
    // オブジェクトの取得
    GameObject ImageArea4MissionFailure_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea4MissionFailure_component;
    // オブジェクトの取得
    GameObject ImageArea5MissionFailure_object;
    // コンポーネントの取得
    [SerializeField] private Image ImageArea5MissionFailure_component;

    //オールミッションサクセステクスチャ
    // オブジェクトの取得
    GameObject ImageAllMissionSuccess_object;
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
        //Table1_text.text = "内容1";
        Table1_text.text = "";

        //Textコンポーネント取得
        Table2_text = GameObject.Find("Table2").GetComponent<Text>();
        //Table2_text.text = "内容2";
        Table2_text.text = "";

        //Textコンポーネント取得
        Table3_text = GameObject.Find("Table3").GetComponent<Text>();
        //Table3_text.text = "内容3";
        Table3_text.text = "";

        //Textコンポーネント取得
        Table4_text = GameObject.Find("Table4").GetComponent<Text>();
        //Table4_text.text = "内容4";
        Table4_text.text = "";

        //Textコンポーネント取得
        Table5_text = GameObject.Find("Table5").GetComponent<Text>();
        //Table5_text.text = "内容5";
        Table5_text.text = "";

        //Textコンポーネント取得
        Table6_text = GameObject.Find("Table6").GetComponent<Text>();
        //Table6_text.text = "内容6";
        Table6_text.text = "";

        //Textコンポーネント取得
        Table7_text = GameObject.Find("Table7").GetComponent<Text>();
        //Table7_text.text = "内容7";
        Table7_text.text = "";

        //Textコンポーネント取得
        Table8_text = GameObject.Find("Table8").GetComponent<Text>();
        //Table8_text.text = "内容8";
        Table8_text.text = "";

        //Textコンポーネント取得
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
        // オブジェクトの取得
        ImageArea1Director_object = GameObject.Find("ImageArea1Director");
        // コンポーネントの取得
        ImageArea1Director_component = ImageArea1Director_object.GetComponent<Image>();
        ImageArea1Director_component.color = Area1DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea2Director_object = GameObject.Find("ImageArea2Director");
        // コンポーネントの取得
        ImageArea2Director_component = ImageArea2Director_object.GetComponent<Image>();
        ImageArea2Director_component.color = Area2DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea3Director_object = GameObject.Find("ImageArea3Director");
        // コンポーネントの取得
        ImageArea3Director_component = ImageArea3Director_object.GetComponent<Image>();
        ImageArea3Director_component.color = Area3DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea4Director_object = GameObject.Find("ImageArea4Director");
        // コンポーネントの取得
        ImageArea4Director_component = ImageArea4Director_object.GetComponent<Image>();
        ImageArea4Director_component.color = Area4DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea5Director_object = GameObject.Find("ImageArea5Director");
        // コンポーネントの取得
        ImageArea5Director_component = ImageArea5Director_object.GetComponent<Image>();
        ImageArea5Director_component.color = Area5DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea6Director_object = GameObject.Find("ImageArea6Director");
        // コンポーネントの取得
        ImageArea6Director_component = ImageArea6Director_object.GetComponent<Image>();
        ImageArea6Director_component.color = Area6DirectortextColor; //画像の透明度を変える

        //エリアテクスチャ
        // オブジェクトの取得
        ImageArea1_object = GameObject.Find("ImageArea1");
        // コンポーネントの取得
        ImageArea1_component = ImageArea1_object.GetComponent<Image>();
        ImageArea1_component.color = Area1DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea2_object = GameObject.Find("ImageArea2");
        // コンポーネントの取得
        ImageArea2_component = ImageArea2_object.GetComponent<Image>();
        ImageArea2_component.color = Area2DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea3_object = GameObject.Find("ImageArea3");
        // コンポーネントの取得
        ImageArea3_component = ImageArea3_object.GetComponent<Image>();
        ImageArea3_component.color = Area3DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea4_object = GameObject.Find("ImageArea4");
        // コンポーネントの取得
        ImageArea4_component = ImageArea4_object.GetComponent<Image>();
        ImageArea4_component.color = Area4DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea5_object = GameObject.Find("ImageArea5");
        // コンポーネントの取得
        ImageArea5_component = ImageArea5_object.GetComponent<Image>();
        ImageArea5_component.color = Area5DirectortextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea6_object = GameObject.Find("ImageArea6");
        // コンポーネントの取得
        ImageArea6_component = ImageArea6_object.GetComponent<Image>();
        ImageArea6_component.color = Area6DirectortextColor; //画像の透明度を変える

        //ミッションサクセステクスチャ
        // オブジェクトの取得
        ImageArea1MissionSuccess_object = GameObject.Find("ImageArea1MissionSuccess");
        // コンポーネントの取得
        ImageArea1MissionSuccess_component = ImageArea1MissionSuccess_object.GetComponent<Image>();
        ImageArea1MissionSuccess_component.color = Area1MissionSuccesstextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea2MissionSuccess_object = GameObject.Find("ImageArea2MissionSuccess");
        // コンポーネントの取得
        ImageArea2MissionSuccess_component = ImageArea2MissionSuccess_object.GetComponent<Image>();
        ImageArea2MissionSuccess_component.color = Area2MissionSuccesstextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea3MissionSuccess_object = GameObject.Find("ImageArea3MissionSuccess");
        // コンポーネントの取得
        ImageArea3MissionSuccess_component = ImageArea3MissionSuccess_object.GetComponent<Image>();
        ImageArea3MissionSuccess_component.color = Area3MissionSuccesstextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea4MissionSuccess_object = GameObject.Find("ImageArea4MissionSuccess");
        // コンポーネントの取得
        ImageArea4MissionSuccess_component = ImageArea4MissionSuccess_object.GetComponent<Image>();
        ImageArea4MissionSuccess_component.color = Area4MissionSuccesstextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea5MissionSuccess_object = GameObject.Find("ImageArea5MissionSuccess");
        // コンポーネントの取得
        ImageArea5MissionSuccess_component = ImageArea5MissionSuccess_object.GetComponent<Image>();
        ImageArea5MissionSuccess_component.color = Area5MissionSuccesstextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea6MissionSuccess_object = GameObject.Find("ImageArea6MissionSuccess");
        // コンポーネントの取得
        ImageArea6MissionSuccess_component = ImageArea6MissionSuccess_object.GetComponent<Image>();
        ImageArea6MissionSuccess_component.color = Area6MissionSuccesstextColor; //画像の透明度を変える

        //ミッションフェイルテクスチャ
        // オブジェクトの取得
        ImageArea2MissionFailure_object = GameObject.Find("ImageArea2MissionFailure");
        // コンポーネントの取得
        ImageArea2MissionFailure_component = ImageArea2MissionFailure_object.GetComponent<Image>();
        ImageArea2MissionFailure_component.color = Area2MissionFailuretextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea4MissionFailure_object = GameObject.Find("ImageArea4MissionFailure");
        // コンポーネントの取得
        ImageArea4MissionFailure_component = ImageArea4MissionFailure_object.GetComponent<Image>();
        ImageArea4MissionFailure_component.color = Area4MissionFailuretextColor; //画像の透明度を変える
        // オブジェクトの取得
        ImageArea5MissionFailure_object = GameObject.Find("ImageArea5MissionFailure");
        // コンポーネントの取得
        ImageArea5MissionFailure_component = ImageArea5MissionFailure_object.GetComponent<Image>();
        ImageArea5MissionFailure_component.color = Area5MissionFailuretextColor; //画像の透明度を変える


        //オールサクセステクスチャ
        // オブジェクトの取得
        ImageAllMissionSuccess_object = GameObject.Find("ImageAllMissionSuccess");
        // コンポーネントの取得
        ImageAllMissionSuccess_component = ImageAllMissionSuccess_object.GetComponent<Image>();
        ImageAllMissionSuccess_component.color = AllMissionSuccesstextColor; //画像の透明度を変える
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
            if (Enemy1 == true)
            {
                Table1_text.text = "敵１を破壊";
            }
            else
            {
                Table1_text.text = "敵１は生存中";
            }
            if (Enemy2 == true)
            {
                Table2_text.text = "敵２を破壊";
            }
            else
            {
                Table2_text.text = "敵２は生存中";
            }
            if (Enemy3 == true)
            {
                Table3_text.text = "敵３を破壊";
            }
            else
            {
                Table3_text.text = "敵３は生存中";
            }
            if (Enemy4 == true)
            {
                Table4_text.text = "敵４を破壊";
            }
            else
            {
                Table4_text.text = "敵４は生存中";
            }

            if (Enemy5 == true)
            {
                Table5_text.text = "敵５を破壊";
            }
            else
            {
                Table5_text.text = "敵５は生存中";
            }
            if (Enemy6 == true)
            {
                Table6_text.text = "敵６を破壊";
            }
            else
            {
                Table6_text.text = "敵６は生存中";
            }
            if (Enemy7 == true)
            {
                Table7_text.text = "敵７を破壊";
            }
            else
            {
                Table7_text.text = "敵７は生存中";
            }

            if (Enemy8 == true)
            {
                Table8_text.text = "敵８を破壊";
            }
            else
            {
                Table8_text.text = "敵８は生存中";
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
            MissionSuccessFadeOut(1);
            DirectorFadeIn(2);
            b_Area2if = true;
            direct_text.text = "エリア2 \n 敵に見つからずに進め！！";
            if (b_SE_Start_Area2 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area2 = false;
            }
            if (enemyFound == false)
            {
                content_text.text = "見つかってない";
            }
            else if (enemyFound == true)
            {
                content_text.text = "見つかった";
                MissionSuccess_text.color = new Color(0.0f, 0.0f, 255.0f);
                MissionSuccess_text.text = "Area2MissionFailure";
                b_Area2MissionFailureFade = true;
                if (b_SE_Failure_Area2 == true)
                {
                    audioSource.PlayOneShot(soundMissionFailure);
                    b_SE_Failure_Area2 = false;
                }
            }
            if (enemyFound == false && b_Area2 == true && b_FoundFalseGOAL == true)
            {
                Score.AddScore(2);
                b_Area2 = false;
                MissionSuccess_text.color = new Color(197.0f, 29.0f, 84.0f);
                MissionSuccess_text.text = "Area2MissionSuccess";
                b_Area2MissionSuccessFade = true;
                audioSource.PlayOneShot(soundMissionSuccess);
                b_All_Area2 = true;
            }
            if (b_Area2MissionSuccessFade == true)
            {
                MissionSuccessFadeIn(2);
            }
            else if (b_Area2MissionFailureFade == true)
            {
                MissionFailureFadeIn(2);
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
            MissionSuccessFadeOut(2);
            MissionFailureFadeOut(2);
            DirectorFadeIn(3);
            b_Area3if = true;
            direct_text.text = "エリア3 \n 爆発物を使って敵を倒せ！！";
            if (b_SE_Start_Area3 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area3 = false;
            }
            if (b_EnemyDrumsDestroy == false)
            {
                content_text.text = "爆発物で倒してない";
            }
            else if (b_EnemyDrumsDestroy == true)
            {
                content_text.text = "爆発物で倒した";
            }
            if (b_EnemyDrumsDestroy == true && b_Area3 == true)
            {
                Score.AddScore(2);
                b_Area3 = false;
                MissionSuccess_text.color = new Color(197.0f, 29.0f, 84.0f);
                MissionSuccess_text.text = "Area3MissionSuccess";
                b_Area3Fade = true;
                audioSource.PlayOneShot(soundMissionSuccess);
                b_All_Area3 = true;
            }
            if (b_Area3Fade == true)
            {
                MissionSuccessFadeIn(3);
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
            MissionSuccessFadeOut(5);
            MissionFailureFadeOut(4);
            DirectorFadeIn(4);
            time -= Time.deltaTime;
            t = Mathf.FloorToInt(time);
            direct_text.text = "エリア6 \n 制限時間内に駆け抜けろ！！";
            content_text.text = "残り時間 : " + t;
            if (b_SE_Start_Area4 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area4 = false;
            }
            if (t <= 0)
            {
                b_TimeOver = true;
                Debug.Log("時間切れ");
                content_text.text = "時間切れ";
                MissionSuccess_text.color = new Color(0.0f, 0.0f, 255.0f);
                MissionSuccess_text.text = "Area6MissionFailure";
                b_Area4MissionFailureFade = true;
                if (b_SE_Failure_Area4 == true)
                {
                    audioSource.PlayOneShot(soundMissionFailure);
                    b_SE_Failure_Area4 = false;
                }
            }
            if (b_TimeOver == false && b_TimeOverFalseGOAL == true && b_Area4 == true)
            {
                Score.AddScore(2);
                b_Area4 = false;
                MissionSuccess_text.color = new Color(197.0f, 29.0f, 84.0f);
                MissionSuccess_text.text = "Area6MissionSuccess";
                b_Area4MissionSuccessFade = true;
                audioSource.PlayOneShot(soundMissionSuccess);
                b_All_Area4 = true;
                if (b_All_Area1 == true && b_All_Area2 == true && b_All_Area3 == true && b_All_Area4 == true && b_All_Area5 == true && b_All_Area6 == true && b_AreaAll == true)
                {
                    Score.AddScore(3);
                    AllMissionSuccess_text.text = "AllMissionSuccess";
                    b_AreaAllFade = true;
                    audioSource.PlayOneShot(soundAllMissionSuccess);
                    b_AreaAll = false;
                }
                else
                {
                    audioSource.PlayOneShot(soundMissionSuccess);
                }
            }
            if (b_Area4MissionSuccessFade == true)
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
            if (b_AreaAllFade == true)
            {
                AllMissionSuccessFadeIn();
            }

            if (b_GOAL4 == true)
            {
                DirectorFadeOut(4);
                content_text.text = "";
            }
        }
        else if (area_Num == 5)
        {
            MissionSuccessFadeOut(6);
            DirectorFadeIn(5);
            b_Area5if = true;
            direct_text.text = "エリア5 \n ダメージを受けるな！！";
            if (b_SE_Start_Area5 == true)
            {
                audioSource.PlayOneShot(soundMissionStart);
                b_SE_Start_Area5 = false;
            }
            if (b_PlayerDamege == false)
            {
                content_text.text = "ダメージを受けていない";
            }
            else if (b_PlayerDamege == true)
            {
                content_text.text = "ダメージを受けた";
                MissionSuccess_text.color = new Color(0.0f, 0.0f, 255.0f);
                MissionSuccess_text.text = "Area5MissionFailure";
                b_Area5MissionFailureFade = true;
                if (b_SE_Failure_Area5 == true)
                {
                    audioSource.PlayOneShot(soundMissionFailure);
                    b_SE_Failure_Area5 = false;
                }
            }
            if (b_PlayerDamege == false && b_DamegeFalseGOAL == true && b_Area5 == true)
            {
                Score.AddScore(2);
                b_Area5 = false;
                MissionSuccess_text.color = new Color(197.0f, 29.0f, 84.0f);
                MissionSuccess_text.text = "Area5MissionSuccess";
                b_Area5MissionSuccessFade = true;
                audioSource.PlayOneShot(soundMissionSuccess);
                b_All_Area5 = true;
            }
            if (b_Area5MissionSuccessFade == true)
            {
                MissionSuccessFadeIn(5);
            }
            else if (b_Area5MissionFailureFade == true)
            {
                MissionFailureFadeIn(5);
            }
            else
            {
                MissionSuccessFadeOut(5);
                MissionFailureFadeOut(5);
            }
            if (b_GOAL5 == true)
            {
                DirectorFadeOut(5);
                content_text.text = "";
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
            if (nood1 == true)
            {
                Table1_text.text = "カプセル１発見";
            }
            else
            {
                Table1_text.text = "カプセル１未発見";
            }

            if (nood2 == true)
            {
                Table2_text.text = "カプセル２発見";
            }
            else
            {
                Table2_text.text = "カプセル２未発見";
            }

            if (nood3 == true)
            {
                Table3_text.text = "カプセル３発見";
            }
            else
            {
                Table3_text.text = "カプセル３未発見";
            }
            if (nood4 == true)
            {
                Table4_text.text = "カプセル４発見";
            }
            else
            {
                Table4_text.text = "カプセル４未発見";
            }
            if (nood5 == true)
            {
                Table5_text.text = "カプセル５発見";
            }
            else
            {
                Table5_text.text = "カプセル５未発見";
            }
            Table6_text.text = "";
            Table7_text.text = "";
            Table8_text.text = "";
            if (b_Area6 == true && nood1 == true && nood2 == true && nood3 == true && nood4 == true && nood5 == true)
            {
                Score.AddScore(2);
                b_Area6 = false;
                MissionSuccess_text.color = new Color(197.0f, 29.0f, 84.0f);
                MissionSuccess_text.text = "Area4MissionSuccess";
                b_Area6Fade = true;
                audioSource.PlayOneShot(soundMissionSuccess);
                b_All_Area6 = true;
            }
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
        }
        if (Input.GetKey("joystick button 13"))
        {
            SceneManager.LoadScene("title");
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
            Debug.Log($"ミッション{areaNumber}フェイルフェードアウト中だよ");
        }
    }
}