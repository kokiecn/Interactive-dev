using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Player
{
    public static int nbLevel = 9;
    public bool[] isClear = new bool[nbLevel];
}

    public class KeepItManager : MonoBehaviour
{
    private const int NUMBER_STAGE = 9;
    private bool[] list_isClear;

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

    public Player player;

    private void Awake()
    {
        _Instance = this;
        list_isClear = new bool[NUMBER_STAGE];

        if (File.Exists(Application.dataPath + "/savedata.json"))
        {
            player = loadPlayerData();
        }
        else
        {
            player = new Player();
            for (int i = 0; i < Player.nbLevel; i++)
            {
                player.isClear[i] = false;
            }
            savePlayerData(player);
        }
    }

    private async void Start()
    {
  
        for (int i = 0; i < Player.nbLevel; i++)
        {
            list_isClear[i] = player.isClear[i];
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
                player.isClear[i] = true;
            }
        }
        savePlayerData(player);
    }

    public void savePlayerData(Player player)
    {
        StreamWriter writer;

        string jsonstr = JsonUtility.ToJson(player);

        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        writer.Write(jsonstr);
        writer.Flush();
        writer.Close();
    }

    public Player loadPlayerData()
    {
        string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/savedata.json");
        datastr = reader.ReadToEnd();
        reader.Close();

        return JsonUtility.FromJson<Player>(datastr);
    }

    public void Load()
    {
        for (int i = 0; i < Player.nbLevel; i++)
        {
            list_isClear[i] = player.isClear[i];
        }
    }
}
