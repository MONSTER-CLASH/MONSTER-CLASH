using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartTitleUIManager : MonoBehaviour
{
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _quitBtn;

    private void Start()
    {
        _startBtn.onClick.AddListener(() =>
        {
            Action action = () => { SceneManager.LoadScene("Start Story Cut Scene"); };
            StartCoroutine(FadeInOutManager.Instance.FadeIn(action));
        });
        _quitBtn.onClick.AddListener(() =>
        {
            Action action = () => { Application.Quit(); };
            StartCoroutine(FadeInOutManager.Instance.FadeIn(action));
        });
    }
}
