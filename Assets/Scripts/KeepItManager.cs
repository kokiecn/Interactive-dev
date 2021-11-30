using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepItManager : MonoBehaviour
{
    private const int NUMBER_STAGE = 9;
    private bool[] list_isClear;

    [SerializeField] private SaveManager savemanager;
    public bool[] List_isClear
    {
        get { return list_isClear; }
    }
    private static KeepItManager _Instance = null;
    public static KeepItManager Instance
    {
        get
        {
            return _Instance;
        }
        private set
        {
            _Instance = value;
        }
    }
    private void Awake()
    {
        _Instance = this;
        list_isClear = new bool[NUMBER_STAGE];

    }


    private async void Start()
    {
        await UniTask.WaitUntil(() => savemanager.initialized);
        for (int i = 0; i < Player.nbLevel; i++)
        {
            list_isClear[i] = savemanager.player.isClear[i];
        }
    }
    private int level;
    public int Level
    {
        get { return level; }
        set
        {
            level = value;
        }
    }

    public void Save(int clearindex)
    {
        for (int i = 0; i < Player.nbLevel; i++)
        {
            if(i == clearindex)
            {
                savemanager.player.isClear[i] = true;
            }
        }
        savemanager.savePlayerData(savemanager.player);
    }

}
