using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    Vector3 mPos;

    // Start is called before the first frame update
    void Start()
    {
        mPos = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        mPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1);
            transform.position = mPos;
    }
}
