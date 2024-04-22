using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveUnitItem : MonoBehaviour
{
    [SerializeField] private GameObject _haveUnitInfoLayer;
    [SerializeField] private Image _unitImage;
    [SerializeField] private TextMeshProUGUI _unitNameText;
    [SerializeField] private TextMeshProUGUI _unitLevelText;
    [SerializeField] private GameObject _equipSelectBtn;
    [SerializeField] private GameObject _selectedImage;

    private UnitData _unitData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ShowUnitInfoLayer);
        _equipSelectBtn.GetComponent<Button>().onClick.AddListener(() => DeckManager.Instance.EquipSelectUnitData = _unitData);
    }

    public void SetItemData(UnitData unitData)
    {
        _unitData = unitData;

        //_unitImage.sprite = _unitData.UnitImage;
        _unitNameText.text = _unitData.UnitName;
        _unitLevelText.text = "레벨 " + _unitData.UnitLevel;
    }

    public void ShowUnitInfoLayer()
    {
        _haveUnitInfoLayer.SetActive(true);
        _haveUnitInfoLayer.GetComponent<HaveUnitInfo>().ShowHaveUnitInfo(_unitData, this);
    }

    public void UpdateUnitItem()
    {
        _unitLevelText.text = "레벨" + _unitData.UnitLevel;
    }

    public void HideSelectedImage()
    {
        _selectedImage.SetActive(false);
    }
}
