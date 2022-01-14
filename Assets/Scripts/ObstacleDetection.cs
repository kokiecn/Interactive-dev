using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField]private Camera cam;
    [SerializeField] private GameObject[] testObj;

    private Rigidbody[] rb;
    public int power = 50;
    private void Start()
    {
        rb = new Rigidbody[testObj.Length];
        for(int i =0; i < testObj.Length; i++)
        {
            rb[i] = testObj[i].GetComponent<Rigidbody>();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Vibration.Vibrate(200);
            cam.GetComponent<CameraShake>().Shake(0.2f, 0.01f);
            for(int i = 0; i < rb.Length; i++)
            {
                rb[i].AddForce(new Vector3(0, 1.0f, 0) * power);
            }
            
        }

    }
}
