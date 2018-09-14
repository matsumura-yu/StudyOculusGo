using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // 試して一番やりやすそうと感じた
    public float speed = 0.04f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 前進
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.forward * speed;
        }

        // 左
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * speed;
        }

        // 右
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * speed;
        }

        // 後退
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.back * speed;
        }
	}
}
