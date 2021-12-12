using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
    public bool DontDestroyEnabled = true;

    // Use this for initialization
    void Start () {
        if (DontDestroyEnabled) {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad (this);
        }
    }
}
