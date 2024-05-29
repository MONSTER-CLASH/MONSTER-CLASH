using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageResultUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stageNameText;
    [SerializeField] private GameObject _stageWinResultUI;
    [SerializeField] private GameObject _stageLoseResultUI;
    [SerializeField] private TextMeshProUGUI _stageTimeText;
    [SerializeField] private TextMeshProUGUI _stageRewardGoldText;
    [SerializeField] private Image[] _stageRewardUnitImages;
    [SerializeField] private Button _stageSelectSceneBtn;
    [SerializeField] private Button _stageRetryBtn;

    private void Awake()
    {
        _stageSelectSceneBtn.onClick.AddListener(() => { SceneManager.LoadScene("Stage Select Scene"); });
        _stageRetryBtn.onClick.AddListener(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
    }

    public void SetStageResultUI(StageData stageData, float stageTime, bool isPlayerWin)
    {
        _stageNameText.text = stageData.StageName;
        _stageTimeText.text = (int)(stageTime / 60) + ":" + (int)(stageTime % 60);

        if (isPlayerWin)
        {
            _stageWinResultUI.SetActive(true);
            _stageRewardGoldText.text = stageData.StageWinGold.ToString();
            _stageSelectSceneBtn.gameObject.SetActive(true);

            for (int i=0; i < _stageRewardUnitImages.Length; i++)
            {
                if (stageData.RewardUnits.Length > i)
                {
                    _stageRewardUnitImages[i].sprite = stageData.RewardUnits[i].CardImage;
                }
                else
                {
                    _stageRewardUnitImages[i].color = Color.clear;
                }
            }
        }
        else
        {
            _stageLoseResultUI.SetActive(true);
            _stageSelectSceneBtn.gameObject.SetActive(true);
            _stageRewardGoldText.text = stageData.StageDefeatGold.ToString();
            _stageRetryBtn.gameObject.SetActive(true);
        }
    }
}
