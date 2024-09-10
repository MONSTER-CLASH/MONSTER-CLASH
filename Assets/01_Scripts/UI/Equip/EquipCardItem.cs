using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipCardItem : MonoBehaviour
{
    public CardData CardData;

    [SerializeField] private int _itemIndex;
    [SerializeField] private Image _cardImage;
    [SerializeField] private TextMeshProUGUI _cardNameText;
    [SerializeField] private TextMeshProUGUI _cardLevelText;
    [SerializeField] private TextMeshProUGUI _cardCostText;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(EquipCard);
    }

    public void UpdateEquipCardData()
    {
        _cardImage.sprite = CardData ? CardData.CardImage : null;
        _cardNameText.text = CardData ? CardData.CardName : "";
        _cardLevelText.text = CardData ? "·¹º§ " + CardData.CardLevel : "";
        _cardCostText.text = CardData ? CardData.SpawnCost.ToString() : "";
    }

    private void EquipCard()
    {
        DeckManager.Instance.EquipCard(_itemIndex);
    }
}
