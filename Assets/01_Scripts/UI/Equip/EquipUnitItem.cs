using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipUnitItem : MonoBehaviour
{
    [SerializeField] private Image _unitImage;
    [SerializeField] private TextMeshProUGUI _unitNameText;
    [SerializeField] private TextMeshProUGUI _unitLevelText;
    [SerializeField] private UnitData _unitData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(EquipUnit);
    }

    private void EquipUnit()
    {
        if (DeckManager.EquipSelectUnitData != null)
        {
            _unitData = DeckManager.EquipSelectUnitData;
            UpdateEquipUnitData();
            DeckManager.EquipSelectUnitData = null;
        }
    }

    private void UpdateEquipUnitData()
    {
        _unitImage.sprite = _unitData.UnitImage;
        _unitNameText.text = _unitData.UnitName;
        _unitLevelText.text = "·¹º§ " + _unitData.UnitLevel;
    }
}
