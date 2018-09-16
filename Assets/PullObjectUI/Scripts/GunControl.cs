using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour {

    private GameObject gaze;
    private GameObject gunModel;
    private static float distance = 15.0f;
    private LineRenderer laser;
    Vector3 tmp;
	// Use this for initialization
	void Start () {
        gaze = transform.Find("Gaze").gameObject;
        gunModel = transform.Find("SciFiGun_Diffuse").gameObject;
        laser = gameObject.GetComponent<LineRenderer>();
	}

    // Update is called once per frame
    void Update() {

        laser.SetPosition(0, transform.position);
        Vector3 angle = transform.rotation * Vector3.forward;
        Debug.Log(angle);

        //if (Input.GetMouseButton(0))
        //{
        //    tmp += 0.001f * (angle);
        //    laser.SetPosition(1, tmp);
        //    laser.SetPosition(0, tmp + tmp);
        //}
        //else
        //{
        //    laser.SetPosition(1, transform.position);
        //}

        RaycastHit hit;
        if (Physics.Raycast(transform.position, angle, out hit, distance))
        {
            Debug.Log(hit);
            gaze.transform.position = hit.point;
            laser.SetPosition(1, hit.point);
            //Debug.Log("当たりました");
            //Debug.Log(hit.transform.gameObject.name);
            hit.transform.gameObject.GetComponent<Renderer>().material.color = Color.red;

            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Debug.Log("DownArrow");

            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                
            }
        }
        else
        {
            gaze.transform.position = transform.position + angle * distance;
            laser.SetPosition(1, transform.position + angle * distance);
        }
        
	}
}
