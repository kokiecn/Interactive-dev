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
            Debug.Log("failed");
            SceneManager.LoadScene("GameoverScene");
        }
    }
}
