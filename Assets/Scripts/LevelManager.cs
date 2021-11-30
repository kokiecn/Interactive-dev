using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene");
        });
    }
}
