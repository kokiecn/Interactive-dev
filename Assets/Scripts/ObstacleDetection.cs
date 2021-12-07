using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    [SerializeField]private Camera cam;

    private void Start()
    {
     
    }
    /*
    // TODOÅ@ëΩï™triggerÇ∂Ç·Ç»Ç¢Ç∆è·äQï®Ç™à¯Ç¡Ç©Ç©ÇÈ
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Vibration.Vibrate(200);
            cam.GetComponent<CameraShake>().Shake(0.2f, 0.01f);
        }

    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Vibration.Vibrate(200);
            cam.GetComponent<CameraShake>().Shake(0.2f, 0.01f);
        }
        Debug.Log("trogger");
    }
}
