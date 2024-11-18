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

    [SerializeField] private CardData _tutorialUnitCardData;
    [SerializeField] private CardData _tutorialSkillCardData;

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

        DeckManager.EquipCardDatas[0] = _tutorialUnitCardData;
        DeckManager.EquipCardDatas[3] = _tutorialSkillCardData;
    }
}
