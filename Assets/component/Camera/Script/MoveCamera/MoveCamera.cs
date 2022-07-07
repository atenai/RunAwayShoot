using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
       // RotationCamera = GameObject.Find("MovieCamera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0.5f, 0));
    }
}
