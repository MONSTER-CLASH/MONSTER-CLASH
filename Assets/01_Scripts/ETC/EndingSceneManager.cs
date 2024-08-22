using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EndingSceneManager : MonoBehaviour
{
    private void Awake()
    {
        SoundManager.Instance.SoundPlay(SoundManager.Instance.EndingSceneBGM, SoundType.BGM);
        Action action = () => { };
        StartCoroutine(FadeInOutManager.Instance.FadeOut(action));
    }
}
