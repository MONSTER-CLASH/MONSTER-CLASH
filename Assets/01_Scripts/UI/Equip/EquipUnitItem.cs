using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipUnitItem : MonoBehaviour
{
    public CardData UnitData;

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
        _unitImage.sprite = UnitData ? UnitData.CardImage : null;
        _unitNameText.text = UnitData ? UnitData.CardName : "";
        _unitLevelText.text = UnitData ? "·¹º§ " + UnitData.CardLevel : "";
    }

    private void EquipUnit()
    {
        DeckManager.Instance.EquipUnit(_itemIndex);
    }
}
