using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameoverSceneManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    private bool pressed;
    private void Start()
    {
        pressed = false;
        
        backButton.onClick.AddListener(() =>
        {
            if (!pressed)
            {
                SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("GameoverScene");
                pressed = true;
            }
        });

    }
}
