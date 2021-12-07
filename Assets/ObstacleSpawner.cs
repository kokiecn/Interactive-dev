using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(1, 10) < 3)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(this.transform);
            cube.transform.localPosition = new Vector3(0, 0, 0.01f);
           // Rigidbody rb = cube.AddComponent<Rigidbody>();
           // rb.useGravity = false;
            BoxCollider bc = cube.GetComponent<BoxCollider>();
            bc.isTrigger = true;
            cube.gameObject.tag = "Obstacle";
        }

    }

}
