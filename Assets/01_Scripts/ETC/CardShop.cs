using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShop : MonoBehaviour
{
    [SerializeField] private Transform _cardShopItemParent;
    [SerializeField] private GameObject _cardShopItem;

    private void Awake()
    {
        InstantiateShopItem();
    }

    private void InstantiateShopItem()
    {
        List<int> rand = new List<int>();
        int index;

        while (rand.Count == 3)
        {
            index = Random.Range(0, CardManager.Instance.CardDatas.Length);
            if (!rand.Contains(index) && !CardManager.Instance.CardDatas[index].HaveCard)
            {
                rand.Add(index);
            }
        }

        for (int i=0; i<rand.Count; i++)
        {
            CardShopItem cardShopItem = Instantiate(_cardShopItem, _cardShopItemParent).GetComponent<CardShopItem>();
            cardShopItem.SetCardShopItemInfo(CardManager.Instance.CardDatas[rand[i]]);
        }
    }
}
