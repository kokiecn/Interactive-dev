using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepItManager : MonoBehaviour
{
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



}
