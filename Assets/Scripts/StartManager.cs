using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour
{
    [SerializeField] private Button startbutton;
    private bool pressed;
    void Start()
    {
        pressed = false;
        startbutton.onClick.AddListener(() =>
        {
            if (!pressed)
            {
                SceneManager.LoadScene("LevelChoiceScene", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("StartScene");
                pressed = true;
            }

        });

    }

}
