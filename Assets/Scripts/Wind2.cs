using UnityEngine;
using System.Collections;

public class Wind2 : MonoBehaviour
{
    public float coefficient;   // ‹ó‹C’ïRŒW”
    public Vector3 velocity;    // •—‘¬

    void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<Rigidbody>() == null)
        {
            return;
        }

        // ‘Š‘Î‘¬“xŒvZ
        var relativeVelocity = velocity - col.GetComponent<Rigidbody>().velocity;

        // ‹ó‹C’ïR‚ğ—^‚¦‚é
        col.GetComponent<Rigidbody>().AddForce(coefficient * relativeVelocity);
    }
}