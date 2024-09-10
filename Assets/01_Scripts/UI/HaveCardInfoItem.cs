using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveCardInfoItem : MonoBehaviour
{
    [SerializeField] private Image _infoIamge;
    [SerializeField] private TextMeshProUGUI _infoNameText;
    [SerializeField] private TextMeshProUGUI _infoValueText;
    [SerializeField] private TextMeshProUGUI _nextLevelInfoValueText;

    public void SetInfo(HaveCardInfoData haveCardInfoData)
    {
        _infoIamge.sprite = haveCardInfoData.InfoImage;
        _infoNameText.text = haveCardInfoData.InfoName;
        _infoValueText.text = haveCardInfoData.InfoValue.ToString("#.##");
        _nextLevelInfoValueText.text = "다음레벨 " + haveCardInfoData.NextLevelInfoValue.ToString("#.##");
    }
}
