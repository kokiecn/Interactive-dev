using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearSceneManager : MonoBehaviour
{
    [SerializeField] private Button startbutton;
    private bool pressd;
    void Start()
    {
        pressd = false;
        startbutton.onClick.AddListener(() =>
        {
            if (!pressd)
            {
                SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("ClearScene");
                pressd = true;
            }

        });
    }
}
