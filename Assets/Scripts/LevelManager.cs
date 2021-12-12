using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button[] button_list;
    private bool pressed;
    private void Start()
    {
        pressed = false;
        backButton.onClick.AddListener(() =>
        {
            if (!pressed)
            {
                SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("LevelChoiceScene");
                pressed = true;
            }

        });
        
        for(int i = 0; i < button_list.Length; i++)
        {
            int tmp = i;
            button_list[tmp].onClick.AddListener(() =>
            {
                if (!pressed)
                {
                    KeepItManager.Instance.Level = tmp;
                    SceneManager.LoadScene("Road", LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync("LevelChoiceScene");
                }
            });
            if (KeepItManager.Instance.List_isClear[i])
            {
                ColorBlock cb = button_list[i].colors;
                cb.normalColor = new Color(1, 0, 0, 1);
                cb.highlightedColor = new Color(1, 0.1f, 0, 1);
                cb.pressedColor = new Color(1, 0.2f, 0, 1);
                button_list[i].colors = cb;
            }
        }

    }
}
