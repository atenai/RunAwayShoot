using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject mEnemyBullet;   //弾の実態

    [SerializeField] private float mSpeed;              //進む速度

    [SerializeField] private float mLimit;              //生存時間/s

    [SerializeField] private float mInterval;           //間隔(攻撃の周期)

    private float mShootingCnt;                         //間隔カウンター

    [SerializeField] private float mReactionMax;        //レティクルの広がりの最大値

    private float mReaction = 0;                        //レティクルの広がりの広がり方

    [SerializeField] private float mReactionInclimentSize;//レティクルの広がりの大きさ

    [SerializeField] private float mReactionDecrimentSize;//レティクルの閉まり方

    private Vector3 mRecoil;

    void Start()
    {
        mShootingCnt = 0;
    }

    public void Shotting()
    {
        mShootingCnt++;
        if (mShootingCnt % mInterval == 0)
        {
            mRecoil = Vector3.zero;
            {
                mRecoil.x = Random.Range(-mReaction, mReaction);
                mRecoil.y = Random.Range(-mReaction, mReaction);
                mRecoil.z = Random.Range(-mReaction, mReaction);
            }

            if (mReaction <= mReactionMax)
            {
                mReaction += mReactionInclimentSize;
            }

            GameObject newBullet =
                Instantiate(mEnemyBullet,
                new Vector3(this.transform.position.x + this.transform.up.x,
                this.transform.position.y,
                this.transform.position.z + this.transform.up.z),
                this.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce((this.transform.up + mRecoil) * 1000.0f * mSpeed);
            //Debug.Log("Forward :"+this.transform.forward);
            //Debug.Log("Right :" + this.transform.up);
            Destroy(newBullet, mLimit);
        }
    }
}
