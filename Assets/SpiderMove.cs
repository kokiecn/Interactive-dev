using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    [SerializeField] private GameObject hand;
    private Transform handTransform;
    private int count = 0;
    private Rigidbody spiderRb;

    private void Start()
    {
        handTransform = hand.transform;
        spiderRb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(count++ == 30)
        {
            
            Vector3 vec = new Vector3(handTransform.up.x, 0, handTransform.up.z);
            if(vec.magnitude > 0.1)
            {
                spiderRb.AddForce(vec * 150);

            } else
            {
                Vector3 vec2 = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f));
                spiderRb.AddForce(vec2);

            }
            count = 0;
        }
    }

}
