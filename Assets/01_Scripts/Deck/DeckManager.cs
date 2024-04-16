using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private Text _currentGoldText;

    [SerializeField] private Transform _haveUnitItemParent;
    [SerializeField] private GameObject _haveUnitItem;

    private void Awake()
    {
        ShowHaveUnitItem();
    }

    private void ShowHaveUnitItem()
    {
        UnitData[] unitDatas = UnitManager.Instance.GetHasUnitDatas();

        for (int i=0; i<unitDatas.Length; i++)
        {

        }
    }
}
