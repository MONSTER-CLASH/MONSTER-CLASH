using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipUnitItem : MonoBehaviour
{
    public UnitData UnitData;

    [SerializeField] private int _itemIndex;
    [SerializeField] private Image _unitImage;
    [SerializeField] private TextMeshProUGUI _unitNameText;
    [SerializeField] private TextMeshProUGUI _unitLevelText;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(EquipUnit);
    }

    public void UpdateEquipUnitData()
    {
        _unitImage.sprite = UnitData ? UnitData.UnitImage : null;
        _unitNameText.text = UnitData ? UnitData.UnitName : "";
        _unitLevelText.text = UnitData ? "·¹º§ " + UnitData.UnitLevel : "";
    }

    private void EquipUnit()
    {
        DeckManager.Instance.EquipUnit(_itemIndex);
    }
}
