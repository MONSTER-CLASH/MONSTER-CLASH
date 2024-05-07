using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;

    public static int Gold;

    [SerializeField] private TextMeshProUGUI _currentGoldText;

    [Header("Have Unit and Skill")]

    [Space()]
    [SerializeField] private Transform _haveUnitItemParent;
    [SerializeField] private GameObject _haveUnitItem;

    [Space()]
    [SerializeField] private Transform _haveSkillItemParent;
    [SerializeField] private GameObject _haveSkillItem;

    [Header("Equipped Unit and Skill")]
    public static UnitData[] EquipUnitDatas = new UnitData[6]; // 장착된 유닛 정보, 스테이지 시작 시 자동으로 업데이트
    public UnitData SelectedHaveUnitData;
    [SerializeField] private EquipUnitItem[] _equipUnitItems = new EquipUnitItem[6];

    [Space()]
    public static SkillData EquipSkillData;
    public SkillData SelectedHaveSkillData;
    [SerializeField] private EquipSkillItem _equipSkillItem; // 장착된 스킬 정보, 스테이지 시작 시 자동으로 업데이트

    private void Awake()
    {
        Instance = this;

        Gold += 10000;
        ShowHaveUnitItem();
        ShowHaveSkillItem();

        UpdateEquipUnitItem();
        _equipSkillItem.UpdateEquipSkillData();
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

    public void EquipUnit(int index)
    {

        if (SelectedHaveUnitData != null)
        {
            for (int i=0; i<_equipUnitItems.Length; i++)
            {
                if (_equipUnitItems[i].UnitData == SelectedHaveUnitData)
                {
                    _equipUnitItems[i].UnitData = _equipUnitItems[index].UnitData;
                }
            }

            _equipUnitItems[index].UnitData = SelectedHaveUnitData;
            UpdateEquipUnitItem();
            HideAllSelectedImage();

            SelectedHaveUnitData = null;
        }
    }

    public void UpdateEquipUnitItem()
    {
        foreach (EquipUnitItem item in _equipUnitItems)
        {
            item.UpdateEquipUnitData();
        }
    }

    public void HideAllSelectedImage()
    {
        foreach(HaveUnitItem item in _haveUnitItemParent.GetComponentsInChildren<HaveUnitItem>())
        {
            item.HideSelectedImage();
        }

        foreach(HaveSkillItem item in _haveSkillItemParent.GetComponentsInChildren<HaveSkillItem>())
        {
            item.HideSelectedImage();
        }
    }

    public void EquipSkill()
    {
        if (SelectedHaveSkillData != null)
        {
            _equipSkillItem.SkillData = SelectedHaveSkillData;
            _equipSkillItem.UpdateEquipSkillData();
            HideAllSelectedImage();
            SelectedHaveSkillData = null;
        }
    }

    public void SetEquipDeck()
    {
        for (int i=0; i<6; i++)
        {
            EquipUnitDatas[i] = _equipUnitItems[i].UnitData;
        }

        EquipSkillData = _equipSkillItem.SkillData;
    }
}
