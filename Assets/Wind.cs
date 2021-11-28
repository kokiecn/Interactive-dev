using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {
    public float coefficient;   // 空気抵抗係数
    public Vector3 velocity;    // 風速
    public Rigidbody rb;
    public bool isTap;


    void Update(){
    	if (Application.isEditor) {
    		if (Input.GetMouseButton(0)) {
    			rb = GetComponent<Rigidbody>();
    		} else {
    			rb = null;
    		}
    	} else {
    		if (Input.touchCount > 0) {
    			Touch touch = Input.GetTouch(0);
    			if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Began) {
        			rb = GetComponent<Rigidbody>();
    			}
    		} else {
    			rb = null;
    		}
    	}
    }


	void OnTriggerStay() {
        if ( rb == null ) {
            return;
        }
        // 相対速度計算
        var relativeVelocity = velocity - rb.velocity;
	    // 空気抵抗を与える
        rb.AddForce(coefficient * relativeVelocity);
	}
}
