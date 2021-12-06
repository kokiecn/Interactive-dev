using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionCheck : MonoBehaviour
{
    private Vector3 handDir;
    private float handDot = 10f;
    // Start is called before the first frame update
    private void Update()
    {
        Debug.Log(transform.right);
        handDir = transform.right;
        if(Vector3.Dot(handDir, new Vector3(-1f, 0, 0)) >0.95)
        {
            Debug.Log("OK");
        }
    }
}
