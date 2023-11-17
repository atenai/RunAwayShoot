using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------------
//  Yamashita Shota
//  弾の発射用（一発一発用）


public class bullet : MonoBehaviour
{
    //発射する実体
    [SerializeField] private GameObject mObject;

    // 進む速度
    [SerializeField] private float mSpeed;
    //　生存時間/s
    [SerializeField] private float mLimit;

    //弾の生成と弾のリミット設定
    public void createBullet(GameObject _obj, Vector3 _frontVec)
    //　※追記:10/09　生成位置を進行方向側へ少し移動 
    {
        {
            GameObject newBullet =
                Instantiate(mObject,
                new Vector3(_obj.transform.position.x + _frontVec.x,
                _obj.transform.position.y + _frontVec.y,
                _obj.transform.position.z + _frontVec.z),
                _obj.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(_frontVec * 1000.0f * mSpeed);
            Destroy(newBullet, mLimit);
        }
    }

    //弾の生成と弾のリミット設定
    //タグもつける
    public void createBullet(GameObject _obj, Vector3 _frontVec, string _tagName)
    // 1:生成位置のオブジェクト 2:進む方向 3:当たり判定のタグ
    //　※追記:10/09　生成位置を進行方向側へ少し移動 
    {
        {
            GameObject newBullet =
                Instantiate(mObject,
                new Vector3(_obj.transform.position.x + _frontVec.x,
                _obj.transform.position.y + _frontVec.y,
                _obj.transform.position.z + _frontVec.z),
                _obj.transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(_frontVec * 1000.0f * mSpeed);
            Destroy(newBullet, mLimit);

            newBullet.tag = _tagName;
        }
    }
}