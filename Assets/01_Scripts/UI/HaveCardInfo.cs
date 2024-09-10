using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveCardInfo : MonoBehaviour
{
    [Header("Upper UI Elements")]
    [SerializeField] private Image _cardImage;
    [SerializeField] private TextMeshProUGUI _cardNameText;
    [SerializeField] private TextMeshProUGUI _cardLevelText;
    [SerializeField] private TextMeshProUGUI _cardTypeText;
    [SerializeField] private TextMeshProUGUI _cardCostText;
    [SerializeField] private TextMeshProUGUI _cardDescriptionText;

    [Header("Lower UI Elements")]
    [SerializeField] private Transform _haveCardInfoItemParent;
    [SerializeField] private GameObject _haveCardInfoItem;

    [Space()]
    [SerializeField] private TextMeshProUGUI _upgradeCostText;
    [SerializeField] private Button _closeBtn;

    private CardData _cardData;
    private HaveCardItem _parentCardItem;

    private void Awake()
    {
        _closeBtn.onClick.AddListener(CloseHaveCardItem);
        transform.position = transform.parent.parent.parent.parent.position;
        _upgradeCostText.transform.parent.GetComponent<Button>().onClick.AddListener(UpgradeCard);
    }

    public void ShowHaveCardInfo(CardData cardData, HaveCardItem parentCardItem = null)
    {
        if (_cardData == null) _cardData = cardData;
        if (_parentCardItem == null) _parentCardItem = parentCardItem;

        _cardImage.sprite = cardData.CardImage;
        _cardNameText.text = _cardData.CardName;
        _cardLevelText.text = "레벨 " + _cardData.CardLevel;
        switch (_cardData.CardType)
        {
            case CardType.Warrior:
                _cardTypeText.text = "전사";
                break;
            case CardType.Wizard:
                _cardTypeText.text = "마법사";
                break;
            case CardType.Range:
                _cardTypeText.text = "원거리 딜러";
                break;
            case CardType.Tank:
                _cardTypeText.text = "탱커";
                break;
            case CardType.Skill:
                _cardTypeText.text = "스킬";
                break;
        }
        _cardCostText.text = _cardData.SpawnCost.ToString();
        _cardDescriptionText.text = _cardData.CardDescription;

        foreach(Transform child in _haveCardInfoItemParent.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i=0; i<_cardData.GetCardInfoData().Length; i++)
        {
            Instantiate(_haveCardInfoItem, _haveCardInfoItemParent).GetComponent<HaveCardInfoItem>().SetInfo(cardData.GetCardInfoData()[i]);
        }

        _upgradeCostText.text = _cardData.CardLevel < _cardData.MaxCardLevel ? _cardData.GetUpgradeCost().ToString() : "최대 레벨";

        transform.SetParent(_parentCardItem.transform.parent.parent, true);
    }

    public void UpgradeCard()
    {
        if (_cardData.CardLevel < _cardData.MaxCardLevel && DeckManager.Gold >= _cardData.GetUpgradeCost())
        {
            DeckManager.Gold -= _cardData.GetUpgradeCost();
            _cardData.UpgradeCard();
            _cardData.CardLevel++;
            ShowHaveCardInfo(_cardData);
            _parentCardItem.UpdateCardItem();
            DeckManager.Instance.UpdateEquipCardItem();
        }
    }

    private void CloseHaveCardItem()
    {
        transform.SetParent(_parentCardItem.transform, true);
        gameObject.SetActive(false);
    }
}
