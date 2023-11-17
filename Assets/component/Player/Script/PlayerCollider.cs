using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField]
    private HitAttackUI mHitCircle;

    [SerializeField]
    private GameObject mWeapon;

    [SerializeField]
    private player mPlayerCon;

    //サウンド
    public AudioClip sound1;
    public AudioClip soundNood;
    AudioSource audioSource;

    void Awake()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        mHitCircle.setPlayerPos(this.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            //敵の銃弾判定
            mHitCircle.OnDamage(other.transform.position);
            mPlayerCon.onDamege(InitializeData.InitializeDataList.InitializeEnemyData.getBulletDamege());
        }

        if (other.tag == "AmmoBox")
        {
            //弾薬回復SE再生
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
            mWeapon.GetComponent<weapon>().addBullet(90);
            Destroy(other.gameObject);
        }

        if (other.tag == "Nood")
        {
            //SE再生
            //音(soundNood)を鳴らす
            audioSource.PlayOneShot(soundNood);
        }
    }
}
