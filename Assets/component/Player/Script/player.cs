using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// YamashitaShota
//　プレイヤー操作


public class player : MonoBehaviour
{
    private GameObject mBody;

    [SerializeField]
    private GameObject mCameraLookAt;           //PlayerCameraと併用

    //[SerializeField]
    private PlayerCamera mCamera;

    //[SerializeField]
    private Canvas mReticle;

    private bool mBattleMode;

    [SerializeField]
    private float mNormalWalkSpeed;

    [SerializeField]
    private float mWeaponWalkSpeed;

    //走るスピードの倍率
    [SerializeField]
    private float mRunMagnification;

    //振り向き速度
    [SerializeField]
    private float mApplySpeed;

    //移動ベクトル
    private Vector3 mVelocity;

    //横回転保管
    private Vector3 mHorizontalCameraVec;

    //所持武器
    //[SerializeField]
    private GameObject mWeapon;

    public PlayerSound Playsound;

    private float mHP;

    //----------------------
    private bool IsReload;
    private int ReloadCnt;
    //----------------------

    // ---------------------
    // コントローラ
    private float L_Stick_x;
    private float L_Stick_y;
    //----------------------
    //アニメーター
    private SampleAnimation AnimetionController;

    //操作ガイドUI
    [SerializeField]
    private GameObject mGuidUI;
    [SerializeField]
    private GameObject mGuidUI2;


    GameObject GB_Score;//スコア呼び出し用

    private void Awake()
    {
        {//情報の取得
            GameObject _obj;
            //ボディ取得
            mBody = this.gameObject.transform.Find("body").gameObject;
            //メインカメラ取得
            _obj = this.gameObject.transform.Find("Main Camera").gameObject;
            mCamera = _obj.GetComponent<PlayerCamera>();
            //レティクル用のキャンバス取得
            _obj = this.gameObject.transform.Find("reticleCamvas").gameObject;
            mReticle = _obj.GetComponent<Canvas>();
            //アサルトライフル取得
            mWeapon = this.gameObject.transform.Find("body").transform.Find("Assult").gameObject;

            AnimetionController = this.gameObject.transform.Find("body").GetComponent<SampleAnimation>();
        }

        mBattleMode = false;
        disablingReticle();
        Playsound = this.gameObject.transform.Find("body").transform.Find("Assult").GetComponent<PlayerSound>();
        L_Stick_x = 0;
        L_Stick_y = 0;

        mHP = InitializeData.InitializeDataList.InitializePlayerData.getHP();

        IsReload = false;
        ReloadCnt = 0;

        GB_Score = GameObject.Find("Score");//スコアを取得

        //デフォルトでは表示しない
        mGuidUI.SetActive(true);
        mGuidUI2.SetActive(false);
    }


    void Update()
    {
        normal();
        weapon();
        guidUIUpdate();
        switchMode();
        ReloadCounter();
        L_Stick_x = Input.GetAxis("PS4 L_Stick_Left&Right");
        L_Stick_y = Input.GetAxis("PS4 L_Stick_Up&Down");

    }

    //操作ガイド
    void guidUIUpdate()
    {
        if(Input.GetButton("PS4 L2"))
        {
            mGuidUI.SetActive(false);
            mGuidUI2.SetActive(true);
            return;
        }
        mGuidUI.SetActive(true);
        mGuidUI2.SetActive(false);
    }


    //構えた状態移動
    private void weapon()
    {
        if (!mBattleMode)
        {
            return;
        }

        {
            //前ベクトル確保を基準に移動(カメラ前情報)
            mVelocity = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                mVelocity += mCamera.getFronVec() * mWeaponWalkSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.S))
                mVelocity -= mCamera.getFronVec() * mWeaponWalkSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
                mVelocity -= mCamera.getRightVec() * mWeaponWalkSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D))
                mVelocity += mCamera.getRightVec() * mWeaponWalkSpeed * Time.deltaTime;
            //----------------------------------------------------------------------------------------
            //コントローラ用
            //----------------------------------------------------------------------------------------
            mVelocity += L_Stick_x * mWeaponWalkSpeed * Time.deltaTime * mCamera.getRightVec();
            mVelocity += L_Stick_y * mWeaponWalkSpeed * Time.deltaTime * mCamera.getFronVec();
            //----------------------------------------------------------------------------------------


            if (mVelocity.magnitude > 0)
            {
                // プレイヤーの位置の更新
                mVelocity.y = 0;
                transform.position += mVelocity;
            }

            uint n = mWeapon.GetComponent<weapon>().getRemainderBulletMagazine();

            if ((Input.GetKey(KeyCode.Space) || Input.GetButton("PS4 R2")) && IsReload==false)
            {
                mWeapon.GetComponent<weapon>().shooting("PlayerBullet");
            }
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("PS4 Square"))
            {
                mWeapon.GetComponent<weapon>().reload();
                Playsound.PlayReloadSound();
                AnimetionController.IsReload_True();
                IsReload = true;
            }
        }
    }

    //通常状態移動
    private void normal()
    {
        if (mBattleMode)
        {
            return;
        }

        {
            // WASD入力から、XZ平面(水平な地面)を移動する方向(velocity)を取得
            mVelocity = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
                mVelocity.z += 1;
            if (Input.GetKey(KeyCode.A))
                mVelocity.x -= 1;
            if (Input.GetKey(KeyCode.S))
                mVelocity.z -= 1;
            if (Input.GetKey(KeyCode.D))
                mVelocity.x += 1;


            //----------------------------------------------------------------------------------------
            //コントローラ用
            //----------------------------------------------------------------------------------------
            mVelocity.x += L_Stick_x;
            mVelocity.z += L_Stick_y;
            //----------------------------------------------------------------------------------------
            // 速度ベクトルの長さを1秒で進むよう
            mVelocity = mVelocity.normalized * mNormalWalkSpeed * Time.deltaTime;
            if (mVelocity.x != 0 || mVelocity.y != 0 || mVelocity.z != 0)
            {
                AnimetionController.IsRun_True();
            }
            if (mVelocity.x == 0 && mVelocity.y == 0 && mVelocity.z == 0)
            {
                AnimetionController.IsRun_False();
            }

            if (mVelocity.magnitude > 0)
            {
                // プレイヤーの回転の更新
                mBody.transform.rotation =
                    Quaternion.Slerp(mBody.transform.rotation,
                    Quaternion.LookRotation(mCamera.gethRot() * mVelocity),
                    mApplySpeed);

                // プレイヤーの位置の更新
                transform.position += mCamera.gethRot() * mVelocity * getMoveManification();
            }
            //if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("PS4 Square"))
            //{
            //    mWeapon.GetComponent<weapon>().reload();
            //    Playsound.PlayReloadSound();
            //    AnimetionController.IsReload_True();
            //    IsReload = true;
            //}
        }
    }

    // ------------------------------
    //  プレイヤーモードの変更
    // ------------------------------
    private void switchMode()
    {
        //----------------------------------------------------------------------------------------
        //コントローラ用
        //----------------------------------------------------------------------------------------
        if (Input.GetButtonDown("PS4 L2"))
        {
            mBattleMode = true;
            mCamera.switchCameraNW();
            activationReticle();
            Playsound.PlaySwitchSound();
            AnimetionController.IsPrepare_True();
        }
        if (Input.GetButtonUp("PS4 L2"))
        {
            mBattleMode = false;
            mCamera.switchCameraWN();
            disablingReticle();
            AnimetionController.IsPrepare_False();
        }
        //----------------------------------------------------------------------------------------

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (mBattleMode)//通常モード
            {
                mBattleMode = false;
                mCamera.switchCameraWN();
                disablingReticle();
                AnimetionController.IsPrepare_False();
            }
            else
            {//戦闘モード(肩越し)
                mBattleMode = true;
                //switchTrun();
                mCamera.switchCameraNW();
                activationReticle();
                Playsound.PlaySwitchSound();
                AnimetionController.IsPrepare_True();
            }
        }
    }

    public bool getPlayerMode()
    {
        return mBattleMode;
    }
    
    //レティクルの有効化
    private void activationReticle()
    {
        mReticle.gameObject.SetActive(true);
    }
    //無効化
    private void disablingReticle()
    {
        mReticle.gameObject.SetActive(false);
    }

    //銃を新たに入手
    private void SetWeapon(GameObject _obj)
    {
        mWeapon = _obj;
    }


    private void ReloadCounter()
    {
        if (IsReload == true)
        {
            ReloadCnt++;
            if (ReloadCnt == 30)
            {
                ReloadCnt = 0;
                IsReload = false;
                AnimetionController.IsReload_False();
            }
        }
    }
    //倍率
    private float getMoveManification()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return mRunMagnification;
        }
        //等倍
        return 1;
    }

    public float getHP()
    {
        return mHP;
    }

    public void onDamege(float _damege)
    {
        mHP -= _damege;

        Score.AddScore(4);//プレイヤーがダメージを受けたらスコアを-100する//柏原
        Director.PlayerDamege();
    }

    private void onResult()
    {   
        
    }
}
