using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    private bool isLoaded;
    private void Start()
    {
        isLoaded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Road")
        {
            if (!isLoaded)
            {
                if (collision.gameObject != null)
                {
                    Destroy(collision.gameObject);
                }
                SceneManager.LoadScene("GameoverScene", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Road");
                isLoaded = true;
            }
        }
    }
}
