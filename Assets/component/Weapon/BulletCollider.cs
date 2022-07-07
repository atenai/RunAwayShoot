using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using HitUI;

public class BulletCollider : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (this.transform.tag != "PlayerBullet")
            return;
        if (collision.other.tag != "Enemy")
            return;

        HitUI.HitPlayerBulletUI.OnHitPlayerBullet();
    }

}
