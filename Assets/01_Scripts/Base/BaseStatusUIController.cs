using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseStatusUIController : MonoBehaviour
{
    [SerializeField] private Transform _baseStatusUIParent;
    [SerializeField] private TextMeshProUGUI _baseNameText;
    [SerializeField] private Image _baseHealthImage;

    private BaseStatusSystem _baseStatusSystem;

    private void Awake()
    {
        _baseStatusSystem = GetComponent<BaseStatusSystem>();
        GetComponent<HealthSystem>().OnDamaged += UpdateBaseStatusUI;
    }

    private void Start()
    {
        _baseNameText.text = _baseStatusSystem.Name;
        _baseHealthImage.fillAmount = _baseStatusSystem.CurrentHealth / _baseStatusSystem.MaxHealth;
    }

    private void Update()
    {
        _baseStatusUIParent.LookAt(Camera.main.transform);
    }

    private void UpdateBaseStatusUI(float damage, GameObject attacker)
    {
        _baseHealthImage.fillAmount = _baseStatusSystem.CurrentHealth / _baseStatusSystem.MaxHealth;
    }
}
