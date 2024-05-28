using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitStatusUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _unitLevelText;
    [SerializeField] private Image _unitHealthImage;

    private UnitStatusSystem _unitStatusSystem;

    private void Awake()
    {
        _unitStatusSystem = GetComponentInParent<UnitStatusSystem>();
        GetComponentInParent<HealthSystem>().OnDamaged += UpdateUnitStatusUI;
    }

    private void Start()
    {
        _unitLevelText.text = _unitStatusSystem.UnitLevel.ToString();
        _unitHealthImage.fillAmount = _unitStatusSystem.CurrentHealth / _unitStatusSystem.MaxHealth;
    }

    private void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void UpdateUnitStatusUI(float damage, GameObject attacker)
    {
        _unitHealthImage.fillAmount = _unitStatusSystem.CurrentHealth / _unitStatusSystem.MaxHealth;
    }
}
