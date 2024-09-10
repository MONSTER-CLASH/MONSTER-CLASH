using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    public CardData[] CardDatas;

    [Header("Have Unit Info Datas")]
    [SerializeField] private Sprite _healthImage;
    [SerializeField] private string _healthName;

    [Space()]
    [SerializeField] private Sprite _attackDamageImage;
    [SerializeField] private string _attackDamageName;

    [Space()]
    [SerializeField] private Sprite _attackSpeedImage;
    [SerializeField] private string _attackSpeedName;

    [Space()]
    [SerializeField] private Sprite _attackRangeImage;
    [SerializeField] private string _attackRangeName;

    [Space()]
    [SerializeField] private Sprite _attackDetectRangeImage;
    [SerializeField] private string _attackDetectRangeName;

    [Space()]
    [SerializeField] private Sprite _moveSpeedImage;
    [SerializeField] private string _moveSpeedName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach(CardData cardData in CardDatas)
        {
            cardData.CardLevel = 1;
        }
    }

    public CardData[] GetHaveCardDatas()
    {
        List<CardData> cardDatas = new List<CardData>();

        for (int i=0; i<CardDatas.Length; i++)
        {
            if (CardDatas[i].HaveCard)
            {
                cardDatas.Add(CardDatas[i]);
            }
        }

        return cardDatas.ToArray();
    }

    public CardData GetCardDataViaName(string cardName)
    {
        for (int i=0; i<CardDatas.Length;i++)
        {
            if (CardDatas[i].CardName == cardName)
            {
                return CardDatas[i];
            }
        }

        Debug.LogWarning("Not Found Card Data Via Name");
        return null;
    }

    public HaveCardInfoData[] GetUnitCardInfoData(UnitStatusData curLevelData, UnitStatusData nextLevelData)
    {
        return new HaveCardInfoData[]
        {
            new HaveCardInfoData
            {
                InfoImage = _healthImage,
                InfoName = _healthName,
                InfoValue = curLevelData.Health,
                NextLevelInfoValue = nextLevelData.Health,
            },

            new HaveCardInfoData
            {
                InfoImage = _attackDamageImage,
                InfoName = _attackDamageName,
                InfoValue = curLevelData.AttackDamage,
                NextLevelInfoValue = nextLevelData.AttackDamage
            },

            new HaveCardInfoData
            {
                InfoImage = _attackSpeedImage,
                InfoName = _attackSpeedName,
                InfoValue = curLevelData.AttackSpeed,
                NextLevelInfoValue = nextLevelData.AttackSpeed
            },

            new HaveCardInfoData
            {
                InfoImage = _attackRangeImage,
                InfoName = _attackRangeName,
                InfoValue = curLevelData.AttackRange,
                NextLevelInfoValue = nextLevelData.AttackRange
            },

            new HaveCardInfoData
            {
                InfoImage = _attackDetectRangeImage,
                InfoName = _attackDetectRangeName,
                InfoValue = curLevelData.AttackDetectRange,
                NextLevelInfoValue = nextLevelData.AttackDetectRange
            },

            new HaveCardInfoData
            {
                InfoImage = _moveSpeedImage,
                InfoName = _moveSpeedName,
                InfoValue = curLevelData.MoveSpeed,
                NextLevelInfoValue = nextLevelData.MoveSpeed
            }
        };
    }
}
