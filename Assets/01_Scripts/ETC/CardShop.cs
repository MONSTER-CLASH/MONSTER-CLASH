using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardShop : MonoBehaviour
{
    [SerializeField] private Transform _shopItemParent;
    [SerializeField] private GameObject _shopItem;

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
            if (!rand.Contains(index)) rand.Add(index);
        }

        for (int i=0; i<rand.Count; i++)
        {
            Instantiate(_shopItem, _shopItemParent);
        }
    }
}
