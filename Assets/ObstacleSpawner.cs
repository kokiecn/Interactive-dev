using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tree1;
    [SerializeField] private GameObject tree2;
    [SerializeField] private GameObject windmilPrefab;
    // Start is called before the first frame update
    void Start()
    {
        int randn = Random.Range(2, 20);
        if (randn < 3)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetParent(this.transform);
            cube.transform.localPosition = new Vector3(0, 0, 0.01f);
            BoxCollider bc = cube.GetComponent<BoxCollider>();
            bc.isTrigger = true;
            cube.gameObject.tag = "Obstacle";
        } else if(randn < 5)
        {
            if(randn == 3)
            {
                tree1.SetActive(false);
                GameObject windmil = Instantiate(windmilPrefab,Vector3.zero, Quaternion.identity);
                windmil.transform.SetParent(this.transform);
                windmil.transform.localPosition = tree1.transform.localPosition;
                windmil.GetComponent<Wind2>().velocity = new Vector3(0, 0, -5);
            }
            else
            {
                tree2.SetActive(false);
                GameObject windmil = Instantiate(windmilPrefab, Vector3.zero, Quaternion.Euler(0,180,0));
                windmil.transform.SetParent(this.transform);
                windmil.transform.localPosition = tree2.transform.localPosition;
                windmil.GetComponent<Wind2>().velocity = new Vector3(0, 0, 5);
            }
        }

    }

}
