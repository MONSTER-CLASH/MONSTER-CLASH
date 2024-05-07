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

    public void UpdateRequestInfo(StageData stageData)
    {
        _requestNameText.text = stageData.StageName;
        _requestDescriptionText.text = stageData.StageDescription;
        _requestRewardGoldText.text = stageData.StageWinGold.ToString();

        for (int i = 0; i < _requestRewardUnitImages.Length; i++)
        {
            if (i < stageData.RewardUnits.Length)
            {
                _requestRewardUnitImages[i].sprite = stageData.RewardUnits[i].UnitImage;
            }
            else
            {
                _requestRewardUnitImages[i].color = Color.clear;
            }
        }
    }
}
