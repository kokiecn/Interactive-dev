using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button[] button_list;
    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("LevelChoiceScene");
        });
    }
}
