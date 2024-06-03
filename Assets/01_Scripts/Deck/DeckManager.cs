using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;

    public static int Gold;

    [SerializeField] private TextMeshProUGUI _currentGoldText;

    [Header("Have Cards")]

    [Space()]
    [SerializeField] private Transform _haveCardItemParent;
    [SerializeField] private GameObject _haveCardItem;

    [Header("Equipped Cards")]
    public static CardData[] EquipCardDatas = new CardData[9]; // 장착된 유닛 정보, 스테이지 시작 시 자동으로 업데이트
    public CardData SelectedHaveCardData;
    [SerializeField] private EquipCardItem[] _equipCardItems = new EquipCardItem[9];

    private void Awake()
    {
        Instance = this;

        Gold += 10000;
        ShowHaveCardItem();

        UpdateEquipCardItem();
    }

    private void ShowHaveCardItem()
    {
        CardData[] cardDatas = CardManager.Instance.GetHaveCardDatas();

        for (int i=0; i<cardDatas.Length; i++)
        {
            Instantiate(_haveCardItem, _haveCardItemParent).GetComponent<HaveCardItem>().SetItemData(cardDatas[i]);
        }
    }

    private void Update()
    {
        _currentGoldText.text = Gold.ToString();
    }

    public void EquipCard(int index)
    {
        if (SelectedHaveCardData != null)
        {
            for (int i=0; i<_equipCardItems.Length; i++)
            {
                if (_equipCardItems[i].CardData == SelectedHaveCardData)
                {
                    _equipCardItems[i].CardData = _equipCardItems[index].CardData;
                }
            }

            _equipCardItems[index].CardData = SelectedHaveCardData;
            UpdateEquipCardItem();
            HideAllSelectedImage();

            SelectedHaveCardData = null;
        }
    }

    public void UpdateEquipCardItem()
    {
        foreach (EquipCardItem item in _equipCardItems)
        {
            item.UpdateEquipCardData();
        }
    }

    public void HideAllSelectedImage()
    {
        foreach(HaveCardItem item in _haveCardItemParent.GetComponentsInChildren<HaveCardItem>())
        {
            item.HideSelectedImage();
        }
    }

    public void SetEquipDeck()
    {
        for (int i=0; i<9; i++)
        {
            EquipCardDatas[i] = _equipCardItems[i].CardData;
        }
    }
}
