using UnityEngine;

public class BaseStatusSystem : StatusSystem
{
    private BaseStatusData _baseStatusData;

    private void Start()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
            _baseStatusData = StageManager.Instance.StageData.PlayerBaseStatusData;
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            _baseStatusData = StageManager.Instance.StageData.EnemyBaseStatusData;

        Name = _baseStatusData.Name;
        MaxHealth = _baseStatusData.Health;
        CurrentHealth = MaxHealth;
        AttackDamage = _baseStatusData.AttackDamage;
        AttackSpeed = _baseStatusData.AttackSpeed;
        AttackRange = _baseStatusData.AttackRange;
    }
}
