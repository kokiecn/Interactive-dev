using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tree1;
    [SerializeField] private GameObject tree2;
    [SerializeField] private GameObject windmilPrefab;
    [SerializeField] private GameObject rockPrefab;
    [SerializeField] private int stageLevel;
    // Start is called before the first frame update
    void Start()
    {
        stageLevel =  KeepItManager.Instance.Level;
        Debug.Log(stageLevel);
        if (stageLevel == 2)
        {
            CreateObstacle(5f);
        }
        else if(stageLevel == 1)
        {
            int randn = Random.Range(1, 20);
            if (randn < 5)
            {
                if (randn < 3)
                {
                    tree1.SetActive(false);
                    GameObject windmil = Instantiate(windmilPrefab, Vector3.zero, Quaternion.identity);
                    windmil.transform.SetParent(this.transform);
                    windmil.transform.localPosition = tree1.transform.localPosition;
                    windmil.GetComponent<Wind2>().velocity = new Vector3(0, 0, -3);
                }
                else
                {
                    tree2.SetActive(false);
                    GameObject windmil = Instantiate(windmilPrefab, Vector3.zero, Quaternion.Euler(0, 180, 0));
                    windmil.transform.SetParent(this.transform);
                    windmil.transform.localPosition = tree2.transform.localPosition;
                    windmil.GetComponent<Wind2>().velocity = new Vector3(0, 0, 3);
                }
            }
        }
        else if (stageLevel == 3)
        {
            CreateObstacle(5f);
        }
        else if(stageLevel == 5)
        {
            CreateObstacle(10f);
        }
        else if (stageLevel == 0 )
        {
            int randn = Random.Range(1, 20);
            if (randn < 3)
            {
                GameObject rock = Instantiate(rockPrefab, Vector3.zero, Quaternion.Euler(-90, 0, 0));
                rock.transform.SetParent(this.transform);
                rock.transform.localPosition = rockPrefab.transform.localPosition;
                rock.gameObject.tag = "Obstacle";
            }
        }
        else if(stageLevel == 4)
        {
            //no obstacle
        }
        else if (stageLevel == 6)
        {
            CreateObstacle(2f);
        }
        else if (stageLevel == 7) 
        {
            CreateObstacle(1f);

        } else if(stageLevel == 8)
        {
            CreateObstacle(5f);
        }

    }
    
    private void CreateObstacle(float windPower)
    {
        if(stageLevel == 8)
        {
            tree1.SetActive(false);
            tree2.SetActive(false);
        }

        int randn = Random.Range(1, 20);
        if (randn < 3)
        {
            GameObject rock = Instantiate(rockPrefab, Vector3.zero, Quaternion.Euler(-90, 0, 0));
            rock.transform.SetParent(this.transform);
            rock.transform.localPosition = rockPrefab.transform.localPosition;
            rock.gameObject.tag = "Obstacle";
        }
        else if (randn < 5)
        {
            if (randn == 3)
            {
                tree1.SetActive(false);
                GameObject windmil = Instantiate(windmilPrefab, Vector3.zero, Quaternion.identity);
                windmil.transform.SetParent(this.transform);
                windmil.transform.localPosition = tree1.transform.localPosition;
                windmil.GetComponent<Wind2>().velocity = new Vector3(0, 0, -windPower);
            }
            else
            {
                tree2.SetActive(false);
                GameObject windmil = Instantiate(windmilPrefab, Vector3.zero, Quaternion.Euler(0, 180, 0));
                windmil.transform.SetParent(this.transform);
                windmil.transform.localPosition = tree2.transform.localPosition;
                windmil.GetComponent<Wind2>().velocity = new Vector3(0, 0, windPower);
            }
        }
    }
}
