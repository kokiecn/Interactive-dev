using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public class Wind : MonoBehaviour {
    public float coefficient;   // 空気抵抗係数
    public Vector3 velocity;    // 風速
    public Rigidbody rb;
    float cnt;
    public float start;
    public float end;

    void Start(){
    	rb = GetComponent<Rigidbody>();	
    }
    

<<<<<<< HEAD
=======
	void Update() {
	   cnt += Time.deltaTime;
	   if (start <= cnt && cnt <= end) {
	   	OnTriggerStay();
	   }
	}


>>>>>>> dev
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