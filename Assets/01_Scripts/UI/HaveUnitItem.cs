using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveUnitItem : MonoBehaviour
{
    [SerializeField] private GameObject _haveUnitInfoLayer;
    [SerializeField] private Image _unitImage;
    [SerializeField] private TextMeshProUGUI _unitName;
    [SerializeField] private TextMeshProUGUI _unitLevel;

    private UnitData _unitData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ShowUnitInfoLayer);
    }

    public void SetItemData(UnitData unitData)
    {
        _unitData = unitData;

        _unitImage.sprite = _unitData.UnitImage;
        _unitName.text = _unitData.UnitName;
        _unitLevel.text = "·¹º§ " + _unitData.UnitLevel;
    }

    public void ShowUnitInfoLayer()
    {

    }
}
