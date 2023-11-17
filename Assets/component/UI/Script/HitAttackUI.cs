using UnityEngine;
using System.Collections;

public class HitAttackUI : MonoBehaviour
{
    // ダメージエフェクト用テクスチャー(面倒なのでインスペクターから設定).
    [SerializeField] private Texture tex;

    private Vector3 attacker;// 攻撃者の座標.
    private float timer; // エフェクト表示タイマー.

    private Vector3 mPlayerPos;

    private Vector3 mPlayerFrontVec;

    // ダメージを受ける関数.
    public void OnDamage(Vector3 sender)
    {
        // 攻撃者の座標を受け取る.
        attacker = sender;

        // タイマーをオンにする.
        timer = 4f;

    }

    void OnGUI()
    {
        // Screenの真ん中を取得
        Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);

        // GUI領域を開始
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        // タイマーが動作中は処理
        if (timer > 0)
        {
            // 色を設定
            GUI.color = new Color(1, 0, 0, timer / 4f);

            // 回転計算.
            Vector3 target = attacker - mPlayerPos; // 差分座標を取得
            target.y = 0; // 水平方向のみ判定するのでＹ軸は無視
            target.Normalize(); // 正規化(必要ないかも)
            float angle = Vector3.Angle(mPlayerFrontVec, target); // 角度を取得
            if (target.x < 0)
                angle *= -1; // 座標がマイナスの時、角度を反転

            // テクスチャを回転
            GUIUtility.RotateAroundPivot(angle - transform.rotation.eulerAngles.y, center);

            // ダメージエフェクトを表示
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

            // タイマーを減算
            timer -= Time.deltaTime;
        }

        // GUI領域を終了.
        GUILayout.EndArea();
    }

    public void setPlayerPos(Vector3 _posVec)
    {
        mPlayerPos = _posVec;
    }

    public void setPlayerCameraVec(Vector3 _frontVec)
    {
        mPlayerFrontVec = _frontVec;
    }
}