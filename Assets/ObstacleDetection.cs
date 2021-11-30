using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetection : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    // TODO　多分triggerじゃないと障害物が引っかかる
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Vibration.Vibrate(200);
            cam.GetComponent<CameraShake>().Shake(0.2f, 0.01f);
        }

    }
}
