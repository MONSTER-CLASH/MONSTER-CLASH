using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _requestNameText;
    [SerializeField] private TextMeshProUGUI _requestDescriptionText;
    [SerializeField] private TextMeshProUGUI _requestRewardGoldText;
    [SerializeField] private Image[] _requestRewardUnitImages;
    private StageData _stageData;

    public void UpdateRequestInfo(StageData stageData)
    {
        _stageData = stageData;

        _requestNameText.text = stageData.StageName;
        _requestDescriptionText.text = stageData.StageDescription;
        _requestRewardGoldText.text = stageData.StageWinGold.ToString();

        for (int i = 0; i < _requestRewardUnitImages.Length; i++)
        {
            if (i < stageData.RewardUnits.Length)
            {
                _requestRewardUnitImages[i].sprite = stageData.RewardUnits[i].CardImage;
            }
            else
            {
                _requestRewardUnitImages[i].color = Color.clear;
            }
        }
    }

    public void StartRequest()
    {
        StageDataManager.Instance.StartStage(_stageData);
    }
}
