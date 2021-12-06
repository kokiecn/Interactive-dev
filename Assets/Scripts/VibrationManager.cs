using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    
    [SerializeField] private CameraShake _camshake;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _camshake.Shake(0.2f, 0.01f);
        }
    }


}
