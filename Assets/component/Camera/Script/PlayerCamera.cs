using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]                                    //プレイヤーの現在情報
    player mPlayerClass;
    [SerializeField]
    GameObject mCameraLookAt;                  //エイム時の注視点オブジェクト(Camera
    [SerializeField]
    GameObject mBodyaLookAt;                   //エイム時の注視点オブジェクト(Body
    [SerializeField]
    AssaultRifle assaultRifle;
    [SerializeField]
    GameObject mControlLookAt;


    [SerializeField]                                    // 回転速度
    float mTurnSpeed;
    [SerializeField]                                    // 通常時注視対象
    Transform mPlayer;

    [SerializeField]
    Vector3 mEye;                               // 構え状態pos

    [SerializeField]                                    // 注視対象プレイヤーからカメラを離す距離
    float mDistance;

    float mAimSpeed;                            // エイム時の感度
    [SerializeField]
    float mAimDefSpeed;                         // エイム時のデフォルト感度
    [SerializeField]
    float mAimAdjusSpeed;                       // 敵を捕らえているときの感度減率
    Quaternion mvRotation;                      // カメラの垂直回転(見下ろし回転)
    Quaternion mhRotation;                      // カメラの水平回転

    Vector3 mWeponRecoli;                       //カメラリコイル保管用
    float mRecoilLarp = 0;                      //カメラのリコイル用のらーぷを扱う値
    bool isShoot;
    Vector3 m_optmaizeVec;


    [SerializeField]
    LayerMask mRayMask;                         //レイ

    [SerializeField]
    HitAttackUI mHitCircle;                     //敵からのダメージサークル

    Vector3 mDataWeponsH = Vector3.zero;        //ボディの起点と銃の起点の差分データ

    [SerializeField]
    float mRStickDeadZone = 0.0f;

    [SerializeField]
    float mCameraLimit = 60f;

    // ---------------------
    // コントローラ
    Vector2 R_Stick;

    void Awake()
    {
        // 回転の初期化
        mvRotation = Quaternion.Euler(20, 0, 0);         // 垂直回転(X軸を軸とする回転)は、30度見下ろす回転
        mhRotation = Quaternion.identity;                // 水平回転(Y軸を軸とする回転)は、無回転
        transform.rotation = mhRotation * mvRotation;    // 最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        // 位置の初期化
        transform.position = mPlayer.position - transform.rotation * Vector3.forward * mDistance;
        // 体回転の初期化
        mBodyaLookAt.transform.position = mCameraLookAt.transform.position;

        // スケールによる差分埋め
        mDataWeponsH.y = 2f;

        R_Stick = Vector2.zero;
        mRecoilLarp = 0;
        isShoot = false;
    }

    void LateUpdate()
    {
        RStickUpDate();

        normalEye();
        weaponEye();
        mHitCircle.setPlayerCameraVec(this.transform.forward);

        cameraRicoilUpdate();

        isShoot = false;
    }

    private void RStickUpDate()
    {
        R_Stick.x = Input.GetAxis("PS4 R_Stick_Left&Right");
        R_Stick.y = Input.GetAxis("PS4 R_Stick_Up&Down");
    }

    private void normalEye()
    {
        if (mPlayerClass.getPlayerMode())
        {
            return;
        }

        // 水平回転の更新
        if (Input.GetKey(KeyCode.J))
        {
            //L
            mhRotation *= Quaternion.Euler(0, -mTurnSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.L))
        {
            //R
            mhRotation *= Quaternion.Euler(0, mTurnSpeed, 0);
        }

        if (mRStickDeadZone >= R_Stick.x || -mRStickDeadZone <= R_Stick.x)
        {
            mhRotation *= Quaternion.Euler(0, R_Stick.x * mTurnSpeed, 0);
        }

        // カメラの回転(transform.rotation)の更新
        transform.rotation = mhRotation * mvRotation;

        // カメラの位置(transform.position)の更新
        transform.position = mPlayer.position + new Vector3(0, 1.5f, 0) - transform.rotation * (Vector3.forward - Vector3.right * 0.15f) * mDistance;
    }

    //銃を構えた状態の眼
    private void weaponEye()
    {
        if (!mPlayerClass.getPlayerMode())
        {
            return;
        }

        Vector3 axisRot = Vector3.zero;
        // カメラ回転角の上限下限
        float _rotY = mCameraLookAt.transform.position.y - this.transform.position.y;

        if (_rotY <= mCameraLimit)
        {
            if (Input.GetKey(KeyCode.I))
            {
                axisRot = -this.transform.right;
            }
        }
        if (_rotY >= -mCameraLimit)
        {
            if (Input.GetKey(KeyCode.K))
            {
                axisRot = this.transform.right;
            }
        }

        if (Input.GetKey(KeyCode.J))
        {
            axisRot = -this.transform.up;
        }
        if (Input.GetKey(KeyCode.L))
        {
            axisRot = this.transform.up;
        }

        //Rスティック操作
        {
            Vector3 _a = Vector3.zero;

            if (_rotY <= mCameraLimit)
            {
                if (mRStickDeadZone <= R_Stick.y)
                {
                    //↑
                    axisRot = -this.transform.right;
                }
            }
            if (_rotY >= -mCameraLimit)
            {
                if (-mRStickDeadZone >= R_Stick.y)
                {
                    //↓
                    axisRot = this.transform.right;
                }
            }
            if (-mRStickDeadZone >= R_Stick.x)
            {
                //←
                _a = -this.transform.up;
            }
            if (mRStickDeadZone <= R_Stick.x)
            {
                //→
                _a = this.transform.up;
            }
            axisRot += _a;
        }
        if (isShoot)
        {
            mRecoilLarp = 0;
        }

        //ControlLookAtLookatオブジェを更新
        mControlLookAt.transform.RotateAround(mPlayer.transform.position, axisRot, mAimSpeed * Time.deltaTime);

        //回転のLookATとリコイルの合成
        recoilCameraLockAt();

        // カメラの回転(transform.rotation)の更新
        this.transform.LookAt(mCameraLookAt.transform);

        // カメラの位置(transform.position)の更新
        transform.position = mPlayer.position + new Vector3(0, mEye.y, 0) - transform.rotation * (Vector3.forward + new Vector3(mEye.x, 0, mEye.z));

        updateRay();

        //BodyとWeponの高さ差分によるレイの角度調整
        mBodyaLookAt.transform.position = mBodyaLookAt.transform.position - mDataWeponsH;

        //ボディをルックアットオブジェクトを用いて回転
        mPlayer.transform.LookAt(mBodyaLookAt.transform);

        mBodyaLookAt.transform.position = mBodyaLookAt.transform.position + mDataWeponsH;
    }

    //レイの更新
    private void updateRay()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f, mRayMask.value))
        {
            //何かがレイに触れた場合 

            if (hit.collider.tag == "Enemy")
            {
                //敵を見つけた際
                mBodyaLookAt.transform.position = ray.GetPoint(hit.distance);
                mAimSpeed = mAimAdjusSpeed * mAimDefSpeed;
            }
            else
            {
                mBodyaLookAt.transform.position = ray.GetPoint(hit.distance);
            }
        }
        else
        {
            mBodyaLookAt.transform.position = mCameraLookAt.transform.position;
            mAimSpeed = mAimDefSpeed;
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 0.1f, true);
    }

    public Quaternion gethRot()
    {
        return mhRotation;
    }

    public Vector3 getFronVec()
    {
        return new Vector3(transform.forward.x, 0, transform.forward.z);
    }

    public Vector3 getRightVec()
    {
        return this.transform.right;
    }

    public Vector3 getPos()
    {
        return Vector3.zero;
    }

    //カメラにリコイル反映処理
    private void recoilCameraLockAt()
    {
        mCameraLookAt.transform.position = mControlLookAt.transform.position + Vector3.Lerp(assaultRifle.getRecoil() / 5, Vector3.zero, mRecoilLarp);
    }

    //リコイル戻し処理
    private void cameraRicoilUpdate()
    {
        if (mRecoilLarp >= 1.0f) return;

        mRecoilLarp += 0.01f;
    }

    //銃を撃ったタイミング入手
    public void setShooting()
    {
        isShoot = true;
    }

    //カメラ切り替え時の方向転換処理
    public void switchCameraNW()
    {
        Vector3 _vec = new Vector3(this.transform.forward.x, 0, this.transform.forward.z);
        _vec = _vec.normalized * 100;
        _vec.y = mDataWeponsH.y;
        mControlLookAt.transform.position = _vec + mPlayer.position;
    }

    public void switchCameraWN()
    {
        Vector3 _vec = new Vector3(this.transform.forward.x, 0, this.transform.forward.z);
        mhRotation = Quaternion.LookRotation(_vec, Vector3.up);
    }
}