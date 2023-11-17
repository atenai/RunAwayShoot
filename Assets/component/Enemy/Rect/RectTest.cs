using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTest : MonoBehaviour
{
    RectTransform rectTransform = null;
    private float xMax;
    private float yMax;
    private float xSpeed;
    private float ySpeed;
    public float FPS;

    void Start()
    {
        FPS = 30;
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, this.gameObject.transform.position);
        xMax = 1920;
        yMax = 1080;
        xSpeed = (xMax - this.gameObject.transform.position.x) / FPS;
        ySpeed = (yMax - this.gameObject.transform.position.y) / FPS;
    }

    void Update()
    {
        rectTransform.position = new Vector3(this.transform.position.x + xSpeed, this.transform.position.y + ySpeed, 0);
        if (this.gameObject.transform.position.x >= xMax && this.gameObject.transform.position.y >= yMax)
        {
            Destroy(this.gameObject);
        }
        //Debug.Log(this.transform.position.y);
    }
}
