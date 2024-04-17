using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    [Header("Have Unit and Skill")]
    public static int Gold;

    [SerializeField] private TextMeshProUGUI _currentGoldText;

    [Space()]
    [SerializeField] private Transform _haveUnitItemParent;
    [SerializeField] private GameObject _haveUnitItem;

    [Space()]
    [SerializeField] private Transform _haveSkillItemParent;
    [SerializeField] private GameObject _haveSkillItem;

    [Header("Equipped Unit and Skill")]
    [SerializeField] private UnitData[] _equippedUnits = new UnitData[6];

    [Space()]
    [SerializeField] private SkillData _equippedSkill;

    private void Awake()
    {
        Gold += 10000;
        ShowHaveUnitItem();
        ShowHaveSkillItem();
    }

    private void ShowHaveUnitItem()
    {
        UnitData[] unitDatas = UnitManager.Instance.GetHasUnitDatas();

        for (int i=0; i<unitDatas.Length; i++)
        {
            Instantiate(_haveUnitItem, _haveUnitItemParent).GetComponent<HaveUnitItem>().SetItemData(unitDatas[i]);
        }
    }

    private void ShowHaveSkillItem()
    {
        SkillData[] skillDatas = SkillManager.Instance.GetHasSkillDatas();

        for (int i=0; i<skillDatas.Length;i++)
        {
            Instantiate(_haveSkillItem, _haveSkillItemParent).GetComponent<HaveSkillItem>().SetItemData(skillDatas[i]);
        }
    }

    private void Update()
    {
        _currentGoldText.text = Gold.ToString();
    }

    public void EquipUnit(UnitData unitData, int index)
    {
        _equippedUnits[index] = unitData;
    }

    public void EquipSkill(SkillData skillData)
    {
        _equippedSkill = skillData;
    }
}
