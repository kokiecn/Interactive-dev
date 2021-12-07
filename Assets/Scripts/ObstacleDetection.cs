using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField]private Camera cam;
    [SerializeField] private GameObject testObj;
    private Rigidbody rb;
    private void Start()
    {
        rb = testObj.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Vibration.Vibrate(200);
            cam.GetComponent<CameraShake>().Shake(0.2f, 0.01f);
            rb.AddForce(transform.up *70);
        }

    }
}
