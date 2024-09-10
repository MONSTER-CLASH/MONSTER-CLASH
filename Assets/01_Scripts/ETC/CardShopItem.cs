using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardShopItem : MonoBehaviour
{
    [SerializeField] private Image _cardImage;
    [SerializeField] private TextMeshProUGUI _cardName;
    [SerializeField] private TextMeshProUGUI _cardPrice;
    private CardData _cardData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PurchaseCard);
    }

    public void SetCardShopItemInfo(CardData cardData)
    {
        _cardData = cardData;
        _cardImage.sprite = cardData.CardImage;
        _cardName.text = cardData.CardName;
        _cardPrice.text = cardData.StorePrice.ToString();
    }

    private void PurchaseCard()
    {
        if (DeckManager.Gold >= _cardData.StorePrice)
        {
            _cardData.HaveCard = true;
            DeckManager.Instance.ShowHaveCardItem();
            gameObject.SetActive(false);
        }
    }
}
