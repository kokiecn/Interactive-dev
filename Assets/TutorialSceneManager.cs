using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSceneManager : MonoBehaviour
{
    [SerializeField] private Button back;
    private bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
        back.onClick.AddListener(() =>
       {
           if (!pressed)
           {
               SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
               SceneManager.UnloadSceneAsync("Tutorial");
               pressed = true;
           }
       });
    }
}
