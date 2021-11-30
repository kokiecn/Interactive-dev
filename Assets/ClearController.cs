using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClearController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Clear());
    }

    private IEnumerator Clear()
    {
       yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("ClearScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Road");

    }
}
