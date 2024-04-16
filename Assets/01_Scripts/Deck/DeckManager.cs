using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public static int Gold;

    [SerializeField] private TextMeshProUGUI _currentGoldText;

    [SerializeField] private Transform _haveUnitItemParent;
    [SerializeField] private GameObject _haveUnitItem;

    private void Awake()
    {
        _currentGoldText.text = Gold.ToString();

        ShowHaveUnitItem();
    }

    private void ShowHaveUnitItem()
    {
        UnitData[] unitDatas = UnitManager.Instance.GetHasUnitDatas();

        for (int i=0; i<unitDatas.Length; i++)
        {
            if (unitDatas[i].HasUnit)
            {
                Instantiate(_haveUnitItem, _haveUnitItemParent).GetComponent<HaveUnitItem>().SetItemData(unitDatas[i]);
            }
        }
    }
}
