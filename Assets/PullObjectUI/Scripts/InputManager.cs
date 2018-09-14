using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 右クリックと何かの操作を押したとき
        if (Input.GetMouseButton(1))
        {
            Debug.Log("右ボタンが押されてます");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("スペースボタンが押されてます");
            }
        }
    }
}
