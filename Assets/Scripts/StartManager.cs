using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour
{
    [SerializeField] private Button startbutton;
    void Start()
    {
        startbutton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("LevelChoiceScene");
        });

    }

}
