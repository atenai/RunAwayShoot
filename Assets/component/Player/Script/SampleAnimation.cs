using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleAnimation : MonoBehaviour
{

    // Animator コンポーネント
    private Animator animator;

    // 設定したフラグの名前
    private const string key_isRun = "IsRun";
    private const string key_isPrepare = "IsPrepare";
    private const string key_isReload = "IsReload";
    // 初期化メソッド
    void Awake()
    {
        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();
    }

    // 1フレームに1回コールされる
    void Update()
    {
        // 矢印下ボタンを押下している
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    // WaitからRunに遷移する
        //    this.animator.SetBool(key_isRun, true);
        //}
        //else
        //{
        //    // RunからWaitに遷移する
        //    this.animator.SetBool(key_isRun, false);
        //}
    }

    public void IsRun_False()
    {
        this.animator.SetBool(key_isRun, false);
    }

    public void IsRun_True()
    {
        this.animator.SetBool(key_isRun, true);
    }

    public void IsPrepare_False()
    {
        this.animator.SetBool(key_isPrepare, false);
    }

    public void IsPrepare_True()
    {
        this.animator.SetBool(key_isPrepare, true);
    }

    public void IsReload_False()
    {
        this.animator.SetBool(key_isReload, false);
    }

    public void IsReload_True()
    {
        this.animator.SetBool(key_isReload, true);
    }
}
