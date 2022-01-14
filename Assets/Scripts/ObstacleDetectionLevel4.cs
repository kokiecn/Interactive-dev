using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetectionLevel4 : MonoBehaviour
{
    [SerializeField]private Camera cam;
    [SerializeField] private GameObject can1;
    [SerializeField] private GameObject can2;
    [SerializeField] private GameObject can3;
    [SerializeField] private GameObject can4;
    [SerializeField] private GameObject can5;
    [SerializeField] private GameObject can6;
    [SerializeField] private GameObject can7;
    private Rigidbody can1_rb;
    private Rigidbody can2_rb;
    private Rigidbody can3_rb;
    private Rigidbody can4_rb;
    private Rigidbody can5_rb;
    private Rigidbody can6_rb;
    private Rigidbody can7_rb;
    private void Start()
    {
        can1_rb = can1.GetComponent<Rigidbody>();
        can2_rb = can2.GetComponent<Rigidbody>();
        can3_rb = can3.GetComponent<Rigidbody>();
        can4_rb = can4.GetComponent<Rigidbody>();
        can5_rb = can5.GetComponent<Rigidbody>();
        can6_rb = can6.GetComponent<Rigidbody>();
        can7_rb = can7.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Vibration.Vibrate(200);
            cam.GetComponent<CameraShake>().Shake(0.2f, 0.01f);
            can1_rb.AddForce(new Vector3(0.1f, 1.0f, 0) * 50);
            can2_rb.AddForce(new Vector3(0, 1.0f, -0.1f) * 50);
            can3_rb.AddForce(new Vector3(0.1f, 1.0f, 0) * 50);
            can4_rb.AddForce(new Vector3(0, 1.0f, 0.1f) * 50);
            can5_rb.AddForce(new Vector3(-0.1f, 1.0f, 0) * 50);
            can6_rb.AddForce(new Vector3(0, 1.0f, 0.1f) * 50);
            can7_rb.AddForce(new Vector3(0.1f, 1.0f, 0) * 50);
        }

    }
}
