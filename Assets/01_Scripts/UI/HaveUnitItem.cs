using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveUnitItem : MonoBehaviour
{
    [SerializeField] private GameObject _haveUnitInfoLayer;
    [SerializeField] private Image _unitImage;
    [SerializeField] private TextMeshProUGUI _unitNameText;
    [SerializeField] private TextMeshProUGUI _unitLevelText;

    private UnitData _unitData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ShowUnitInfoLayer);
    }

    public void SetItemData(UnitData unitData)
    {
        _unitData = unitData;

        //_unitImage.sprite = _unitData.UnitImage;
        _unitNameText.text = _unitData.UnitName;
        _unitLevelText.text = "·¹º§ " + _unitData.UnitLevel;
    }

    public void ShowUnitInfoLayer()
    {
        Debug.Log("ShowUnitInfoLayer");
    }
}
