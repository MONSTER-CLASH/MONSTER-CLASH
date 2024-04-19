using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatusUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unitNameText;
    [SerializeField] private TextMeshProUGUI _unitLevelText;
    [SerializeField] private Image _unitHealth;

    private UnitStatusSystem _unitStatusSystem;

    private void Awake()
    {
        _unitStatusSystem = GetComponent<UnitStatusSystem>();
        GetComponent<HealthSystem>().OnDamaged += UpdateUnitStatusUI;
    }

    private void Start()
    {
        _unitNameText.text = _unitStatusSystem.Name;
        _unitLevelText.text = _unitStatusSystem.UnitLevel.ToString();

        _unitHealth.fillAmount = _unitStatusSystem.CurrentHealth / _unitStatusSystem.MaxHealth;
    }

    private void UpdateUnitStatusUI(float damage, GameObject attacker)
    {
        _unitHealth.fillAmount = _unitStatusSystem.CurrentHealth / _unitStatusSystem.MaxHealth;
    }
}
