using UnityEngine;
using System.Collections;

public class Wind2 : MonoBehaviour
{
    public float coefficient;   // ��C��R�W��
    public Vector3 velocity;    // ����

    void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<Rigidbody>() == null)
        {
            return;
        }

        // ���Α��x�v�Z
        var relativeVelocity = velocity - col.GetComponent<Rigidbody>().velocity;

        // ��C��R��^����
        col.GetComponent<Rigidbody>().AddForce(coefficient * relativeVelocity);
    }
}