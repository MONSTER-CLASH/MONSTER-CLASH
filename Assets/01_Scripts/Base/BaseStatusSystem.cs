using UnityEngine;

public class BaseStatusSystem : StatusSystem
{
    private BaseStatusData _baseStatusData;

    private void Awake()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
            _baseStatusData = StageManager.StageData.PlayerBaseStatusData;
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
            _baseStatusData = StageManager.StageData.EnemyBaseStatusData;

        Name = _baseStatusData.Name;
        MaxHealth = _baseStatusData.Health;
        CurrentHealth = MaxHealth;
        _attackDamage = _baseStatusData.AttackDamage;
        AttackSpeed = _baseStatusData.AttackSpeed;
        AttackRange = _baseStatusData.AttackRange;
    }
}
