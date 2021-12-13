using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
	{
		Vector3 p = cam.transform.position;
		p.y = transform.position.y;
		transform.LookAt(p);
	}
}
