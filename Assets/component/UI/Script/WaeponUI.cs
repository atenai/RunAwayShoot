using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaeponUI : MonoBehaviour
{
    [SerializeField] Text mUI01;
    [SerializeField] Text mUI02;
    [SerializeField] GameObject mObj;

    void Awake() { }

    void Update()
    {
        uint _u1 = mObj.GetComponent<AssaultRifle>().getRemainderBulletMagazine();
        uint _u2 = mObj.GetComponent<AssaultRifle>().getRemainderBulletContet();
        mUI01.text = _u1.ToString();
        mUI02.text = _u2.ToString();
    }
}
