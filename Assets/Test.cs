using UnityEngine;
public class Test : MonoBehaviour
{
    private double _lastCompassUpdateTime = 0;
    private Quaternion _correction = Quaternion.identity;
    private Quaternion _targetCorrection = Quaternion.identity;
    private Quaternion _compassOrientation = Quaternion.identity;

    void Start()
    {
        Input.gyro.enabled = true;
        Input.compass.enabled = true;
        

    }

    void Update()
    {
        transform.rotation = Input.gyro.attitude;
    }
}