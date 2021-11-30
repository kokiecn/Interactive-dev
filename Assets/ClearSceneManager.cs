using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearSceneManager : MonoBehaviour
{
    [SerializeField] private Button startbutton;
    void Start()
    {
        startbutton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("ClearScene");
        });
    }
}
