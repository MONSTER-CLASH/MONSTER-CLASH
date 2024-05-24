using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveCardItem : MonoBehaviour
{
    [SerializeField] private GameObject _haveCardInfoLayer;
    [SerializeField] private Image _cardImage;
    [SerializeField] private TextMeshProUGUI _cardNameText;
    [SerializeField] private TextMeshProUGUI _cardLevelText;
    [SerializeField] private TextMeshProUGUI _cardCostText;
    [SerializeField] private GameObject _equipSelectBtn;
    [SerializeField] private GameObject _selectedImage;

    private CardData _cardData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ShowCardInfoLayer);
        _equipSelectBtn.GetComponent<Button>().onClick.AddListener(() => {
            DeckManager.Instance.HideAllSelectedImage();
            DeckManager.Instance.SelectedHaveCardData = _cardData;
            _selectedImage.SetActive(true);
        });
    }

    public void SetItemData(CardData cardData)
    {
        _cardData = cardData;

        _cardImage.sprite = _cardData.CardImage;
        _cardNameText.text = _cardData.CardName;
        _cardLevelText.text = "·¹º§ " + _cardData.CardLevel.ToString();
        _cardCostText.text = _cardData.SpawnCost.ToString();
    }

    public void ShowCardInfoLayer()
    {
        _haveCardInfoLayer.SetActive(true);
        _haveCardInfoLayer.GetComponent<HaveCardInfo>().ShowHaveCardInfo(_cardData, this);
    }

    public void UpdateCardItem()
    {
        _cardLevelText.text = _cardData.CardLevel.ToString();
    }

    public void HideSelectedImage()
    {
        _selectedImage.SetActive(false);
    }
}
