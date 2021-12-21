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
        if(count++ == 120)
        {
            Vector3 vec = new Vector3(handTransform.up.x, 0, handTransform.up.z) * 200;
            spiderRb.AddForce(vec);
            count = 0;
        }
    }

}
