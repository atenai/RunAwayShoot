using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ----------------------------------
// YamashitaShota
//  武器クラス(親)
//
// ----------------------------------


public class weapon : MonoBehaviour
{
    //持てる総弾数
    [SerializeField]
  　protected private uint mMaxBullet;
    //残弾数（手持ち）
    [SerializeField]
    protected private uint mRemainderBulletContet;
    //マガジンの総弾数
    [SerializeField]
    protected private uint mMaxBulletMagazine;
    //残弾数（マガジン）
    [SerializeField]
    protected private uint mRemainderBulletMagazine;
    


    //レート
    [SerializeField]
    protected private float mShootSpeed;

    //　弾そのもの
    [SerializeField]
    protected private GameObject mBulletPrefab;

    //前ベクトル保管
    [SerializeField]
    protected private GameObject mFrontVec;
    
    public virtual void Awake()
    {
        {

        }
        reload();
    }
    
    public virtual void Update()
    {
    
    }
    
    public virtual void shooting(string _tagName)
    {
        //Debug.Log("NonWeapon");
    }
    

    //リロード
    public void reload()
    {
        //リロード可能か？
        if(　mMaxBulletMagazine <=  mRemainderBulletMagazine)
        {//不可能
            return;
        }
  
        //可能
        //手持ちの弾薬がマガジン最大値分あるか
        if(mMaxBulletMagazine <= mRemainderBulletContet)
        {//あった場合
            mRemainderBulletContet += mRemainderBulletMagazine;
            mRemainderBulletContet -= mMaxBulletMagazine;
            mRemainderBulletMagazine = mMaxBulletMagazine;
        }
        else
        {
            uint _remainderbullet = mRemainderBulletContet;
            mRemainderBulletContet = 0;
            mRemainderBulletMagazine = _remainderbullet;
        }
    }

    //　弾の追加
    public void addBullet(uint _num)
    {
        mRemainderBulletContet += _num;

        if(mRemainderBulletContet >= mMaxBullet)
        {
            mRemainderBulletContet = mMaxBullet;
        }
    }

    public uint getRemainderBulletMagazine()
    {
        return mRemainderBulletMagazine;
    }

    public uint getRemainderBulletContet()
    {
        return mRemainderBulletContet;
    }

}
