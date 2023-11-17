using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleLogo : MonoBehaviour
{
    bool titlelogo;

    [SerializeField] private GameObject Title;

    void Awake()
    {
        titlelogo = false;
        Title.SetActive(false);
    }

    void Update()
    {
        if (titlelogo)
        {
            Title.SetActive(true);
        }
    }

    //タイトルロゴ表示
    public void titlelogoUp()
    {
        titlelogo = true;
    }
}
