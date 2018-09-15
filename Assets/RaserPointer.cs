using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaserPointer : MonoBehaviour {

    [SerializeField]
    private LineRenderer laserPointerRenderer;
    [SerializeField]
    private GameObject hand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray pointerRay = new Ray(hand.transform.position, hand.transform.forward);

        laserPointerRenderer.SetPosition(0, pointerRay.origin);
    }
}
