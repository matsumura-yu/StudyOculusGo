using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // 試して一番やりやすそうと感じた
    public float speed = 0.04f;

    public Camera mainCamera;
    // Use this for initialization
    private Vector3 newAngle = new Vector3(0, 0, 0);
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

        // カメラの回転
        if (Input.GetMouseButton(1))
        {
            Debug.Log("右ボタンが押されてます");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("スペースボタンが押されてます");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            //newAngle = mainCamera.transform.eulerAngles;
            newAngle = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))

        {
            Vector3 tmp = Input.mousePosition;

            float x = (tmp - newAngle).x;
            float y = (tmp - newAngle).y;
            Transform myTransform = this.transform;
            myTransform.Rotate(new Vector3(-y ,x, 0.0f) * 0.001f, Space.World);
        }


    }
}
