using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverSceneManager : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private Button homeButton;
    private bool retryPressed;
    private bool homePressed;
    private void Start()
    {
        retryPressed = false;
        homePressed = false;

        retryButton.onClick.AddListener(() =>
        {
            if (!retryPressed)
            {
                SceneManager.LoadScene("LevelChoiceScene", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("GameoverScene");
                retryPressed = true;
            }
        });
        homeButton.onClick.AddListener(() =>
        {
            if (!retryPressed)
            {
                SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("GameoverScene");
                retryPressed = true;
            }
        });

    }
}
