using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ObjToCarry")
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameoverScene",LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Road");
        }
    }
}
