using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// public class StartManager : MonoBehaviour
// {
//     [SerializeField] private Button startbutton;
//     private bool pressed;
//     void Start()
//     {
//         pressed = false;
//         startbutton.onClick.AddListener(() =>
//         {
//             if (!pressed)
//             {
//                 SceneManager.LoadScene("LevelChoiceScene", LoadSceneMode.Additive);
//                 SceneManager.UnloadSceneAsync("StartScene");
//                 pressed = true;
//             }

//         });

//     }

// }

public class StartManager : MonoBehaviour
{
    [SerializeField] private Button startbutton;
    [SerializeField] private Button tutoButton;
    private bool pressed;
    void Start()
    {
        pressed = false;

        startbutton.onClick.AddListener(() =>
        {
            if (!pressed)
            {
                Invoke("Scene", 2);
            }

        });

        tutoButton.onClick.AddListener(() =>
        {
            if (!pressed)
            {
                SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("StartScene");
                pressed = true;
            }
        });
    }

    void Scene()
    {
        SceneManager.LoadScene("LevelChoiceScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("StartScene");
        pressed = true;
    }

}

