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
    public static UnitData[] EquipUnitDatas = new UnitData[6];
    public UnitData SelectedHaveUnitData;
    [SerializeField] private EquipUnitItem[] _equipUnitItems = new EquipUnitItem[6];

    [Space()]
    public static SkillData EquipSkillData;
    public SkillData SelectedHaveSkillData;
    [SerializeField] private EquipSkillItem _equipSkillItem;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetEquipDeck();
            SceneManager.LoadScene("Main Stage 1");
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
