using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------
// Yamashita Shota
// あさるとライフル
//　ウェポンクラス継承

public class AssaultRifle : weapon
{
    //レートコントロール用
    private float mLaterFlame = 0;

    //レティクルの広がりの最大値
    [SerializeField] private float mReactionMax;

    //レティクルの広がりの広がり方
    private float mReaction = 0;
    //レティクルの広がりの大きさ
    [SerializeField] private float mReactionInclimentSize;
    //レティクルの閉まり方
    [SerializeField] private float mReactionDecrimentSize;

    private Vector3 mRecoil;

    public PlayerSound Playsound;

    //emptyサウンド再生間隔
    private bool Recastsound = true;
    private int Recastcount = 0;
    private int Recastlimit = 30;

    [SerializeField] private ReticleScr mReticle;

    private Vector3 mRecoilSave;

    [SerializeField] private PlayerCamera mCamera;

    public void Awake()
    {
        Playsound = this.gameObject.GetComponent<PlayerSound>();
        mRecoilSave = Vector3.zero;
    }

    public override void Update()
    {
        if (mReaction >= 0)
            mReaction -= mReactionDecrimentSize;

    }

    public void LateUpdate()
    {
        mReticle.setReticleSize(mReaction);
    }

    //発射
    public override void shooting(string _tagName)
    {
        if (mRemainderBulletMagazine <= 0)
        {
            //残弾なし状態
            if (Recastsound == true)
            {
                Playsound.PlayBulletEmptySound();
                Recastcount = 0;
                Recastsound = false;
            }
            else if (Recastsound == false)
            {
                Recastcount++;
                if (Recastcount >= Recastlimit)
                {
                    Recastsound = true;
                }
            }
            return;
        }
        if (mLaterFlame < mShootSpeed)
        {
            //レートから弾の発生をコントロール
            mLaterFlame += Time.deltaTime;
            return;
        }

        //ブレ幅生成
        mRecoil = Vector3.zero;
        {
            mRecoil.x = Random.Range(-mReaction, mReaction);
            mRecoil.y = Random.Range(0, mReaction);
            mRecoil.z = Random.Range(-mReaction, mReaction);
        }

        mRecoilSave = mRecoil;
        Vector3 _front = (mFrontVec.transform.position + mRecoil) - this.transform.position;

        mBulletPrefab.GetComponent<bullet>().createBullet(this.gameObject, _front.normalized, _tagName);

        mRemainderBulletMagazine -= 1;

        if (mReaction <= mReactionMax)
        {
            mReaction += mReactionInclimentSize;
        }

        mLaterFlame = 0;
        Playsound.PlayAssultSound();

        mReticle.setReticleSize(mReaction);
        mCamera.setShooting();

    }

    public float getReactionSize()
    {
        return mReaction;
    }

    public Vector3 getRecoil()
    {
        return mRecoilSave;
    }

}
