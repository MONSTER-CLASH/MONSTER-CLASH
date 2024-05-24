using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveUnitInfo : MonoBehaviour
{
    [Header("Upper UI Elements")]
    [SerializeField] private Image _unitImage;
    [SerializeField] private TextMeshProUGUI _unitNameText;
    [SerializeField] private TextMeshProUGUI _unitLevelText;
    [SerializeField] private TextMeshProUGUI _unitPositionText;
    [SerializeField] private TextMeshProUGUI _unitCostText;
    [SerializeField] private TextMeshProUGUI _unitDescriptionText;

    [Header("Lower UI Elements")]
    [SerializeField] private Transform _haveCardInfoItemParent;
    [SerializeField] private GameObject _haveCardInfoItem;

    [Space()]
    [SerializeField] private TextMeshProUGUI _upgradeCostText;

    private CardData _unitData;
    private HaveUnitItem _parentUnitItem;

    private void Awake()
    {
        transform.position = transform.parent.parent.parent.parent.position;
        _upgradeCostText.transform.parent.GetComponent<Button>().onClick.AddListener(UpgradeUnit);
    }

    public void ShowHaveUnitInfo(CardData unitData, HaveUnitItem parentUnitItem = null)
    {
        if (_unitData == null) _unitData = unitData;
        if (_parentUnitItem == null) _parentUnitItem = parentUnitItem;

        _unitImage.sprite = unitData.CardImage;
        _unitNameText.text = _unitData.CardName;
        _unitLevelText.text = "레벨 " + _unitData.CardLevel;
        switch (_unitData.CardType)
        {
            case CardType.Warrior:
                _unitPositionText.text = "전사";
                break;
            case CardType.Wizard:
                _unitPositionText.text = "마법사";
                break;
            case CardType.Range:
                _unitPositionText.text = "원거리 딜러";
                break;
            case CardType.Tank:
                _unitPositionText.text = "탱커";
                break;
        }
        _unitCostText.text = _unitData.SpawnCost.ToString();
        _unitDescriptionText.text = _unitData.CardDescription;

        foreach(Transform child in _haveCardInfoItemParent.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i=0; i<_unitData.GetCardInfoData().Length; i++)
        {
            Instantiate(_haveCardInfoItem, _haveCardInfoItemParent).GetComponent<HaveCardInfoItem>().SetInfo(unitData.GetCardInfoData()[i]);
        }

        _upgradeCostText.text = _unitData.CardLevel < _unitData.MaxCardLevel ? _unitData.GetUpgradeCost().ToString() : "최대 레벨";
    }

    public void UpgradeUnit()
    {
        if (_unitData.CardLevel < _unitData.MaxCardLevel && DeckManager.Gold >= _unitData.GetUpgradeCost())
        {
            DeckManager.Gold -= _unitData.GetUpgradeCost();
            _unitData.UpgradeCard();
            _unitData.CardLevel++;
            ShowHaveUnitInfo(_unitData);
            _parentUnitItem.UpdateUnitItem();
            DeckManager.Instance.UpdateEquipUnitItem();
        }
    }
}
