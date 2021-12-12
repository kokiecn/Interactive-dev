using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotate2 : MonoBehaviour
{
    private Vector3 deviceDown = new Vector3(0, 0, -1);
    private Vector3 handForward;
    private Quaternion q_real;
    private Quaternion q_hand;
    private void Start()
    {
        Input.gyro.enabled = true;
        handForward = transform.forward;
        Quaternion test = Quaternion.FromToRotation(new Vector3(0, 0, -1), new Vector3(1, 0, 0));
        test = changeAxis(test);
         q_hand = this.transform.rotation;
    }

    private void Update()
    {
        Quaternion move = Quaternion.FromToRotation(Input.gyro.gravity, deviceDown);
        move = changeAxis(move);
        // 合成して、自身に設定
        this.transform.rotation = q_hand * move;

    }
    static Quaternion changeAxis(Quaternion q)
    {
        var euler = q.eulerAngles;
        return Quaternion.Euler(-euler.y, euler.z , euler.x);
    }

}
