using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverSceneManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("GameoverScene");
            
        });

    }
}
