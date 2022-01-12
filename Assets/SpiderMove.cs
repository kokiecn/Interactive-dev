using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    private Transform handTransform;
    private int count = 0;
    private Rigidbody spiderRb;
    private bool tilted = false;
    Vector3 dir;
    private void Start()
    {
        handTransform = hand.transform;
        spiderRb = this.GetComponent<Rigidbody>();
        int x = Random.Range(50, 100);
        int z = Random.Range(50, 100);
        x = x % 2 == 1 ? x : -x;
        z = z % 2 == 1 ? z : -z;
        dir = new Vector3(x, 0, z);
    }

    private void Update()
    {
        if(count++ == 25)
        {
            Vector3 vec = new Vector3(handTransform.up.x, 0, handTransform.up.z);
            if(vec.magnitude > 0.2)
            {
                spiderRb.AddForce(vec * 150);
                tilted = true;

            } else
            {
                if (tilted)
                {
                   int x = Random.Range(50, 100);
                    int z = Random.Range(50, 100);
                    x = x % 2 == 1 ? x : -x;
                    z = z % 2 == 1 ? z : -z;
                    dir = new Vector3(x, 0, z);
                }
                spiderRb.AddForce(dir);
                tilted = false;

            }
            count = 0;
        }
    }

}
