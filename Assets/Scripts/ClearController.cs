using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearController : MonoBehaviour
{
    [SerializeField] private Material myskybox;
    [SerializeField] private Text time;
    public float gameTime = 30.0f;
    float currentTime;
    private void Awake()
    {
        RenderSettings.skybox = myskybox;
    }
    private void Start()
    {
        currentTime = gameTime;
        StartCoroutine(Clear());
    }

    private  void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }
        time.text = ((int)currentTime).ToString();
    }
    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(30f);
        KeepItManager.Instance.Save(KeepItManager.Instance.Level);
        KeepItManager.Instance.Load();
        SceneManager.LoadScene("ClearScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Road");

    }
}
