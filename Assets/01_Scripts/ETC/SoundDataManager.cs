using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataManager : MonoBehaviour
{
    public static SoundDataManager Instance;

    public AudioClip StageSelectSceneBGM;
    public AudioClip StageSceneBGM;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
