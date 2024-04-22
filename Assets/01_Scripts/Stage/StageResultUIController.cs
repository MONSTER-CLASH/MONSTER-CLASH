using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageResultUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stageLevelText;
    [SerializeField] private TextMeshProUGUI _stageResultText;
    [SerializeField] private TextMeshProUGUI _stageTimeText;
    [SerializeField] private TextMeshProUGUI _stageRewardGoldText;
    [SerializeField] private Button _stageSelectSceneBtn;
    [SerializeField] private Button _stageRetryBtn;

    private void Awake()
    {
        _stageSelectSceneBtn.onClick.AddListener(() => { SceneManager.LoadScene("Stage Select Scene"); });
        _stageRetryBtn.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
    }

    public void SetStageResultUI(int stageLevel, float stageTime, int stageRewardGold, bool isPlayerWin)
    {
        _stageTimeText.text = "스테이지 " + stageLevel;
        _stageTimeText.text = (int)(stageTime / 60) + ":" + (int)(stageTime % 60);
        _stageRewardGoldText.text = "+" + stageRewardGold;

        if (isPlayerWin)
        {
            _stageResultText.text = "승리!";

            _stageSelectSceneBtn.gameObject.SetActive(true);
        }
        else
        {
            _stageResultText.text = "패배..";

            _stageSelectSceneBtn.gameObject.SetActive(true);
            _stageRetryBtn.gameObject.SetActive(true);
        }
    }
}
