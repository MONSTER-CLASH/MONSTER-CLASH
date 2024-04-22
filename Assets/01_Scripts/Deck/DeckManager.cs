using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckManager : MonoBehaviour
{
    public static DeckManager Instance;

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
    [SerializeField] private EquipUnitItem[] _equipUnitItems = new EquipUnitItem[6];
    public UnitData SelectedHaveUnitData;

    [Space()]
    [SerializeField] private EquipSkillItem _equipSkillItem;
    public SkillData EquipSelectSkillData;

    private void Awake()
    {
        Instance = this;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("TestScene");
        }
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
    }

    public void EquipSkill()
    {
        if (EquipSelectSkillData != null)
        {
            _equipSkillItem.SkillData = EquipSelectSkillData;
            _equipSkillItem.UpdateEquipSkillData();
            EquipSelectSkillData = null;
        }
    }
}
