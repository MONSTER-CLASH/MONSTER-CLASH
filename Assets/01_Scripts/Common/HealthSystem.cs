using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    /// <summary>
    /// float : ���� ���� �����, GameObject : ������
    /// </summary>
    public Action<float, GameObject> OnDamaged;
    /// <summary>
    /// float : ���� ���� ����, GameObject : ġ����
    /// </summary>
    public Action<float, GameObject> OnHealed;
    private Action<GameObject> _onDead;
    /// <summary>
    /// GameObject : óġ��
    /// </summary>
    public Action<GameObject> OnDead
    {
        get => _isDead ? null : _onDead;
        set
        {
            if (_isDead)
            {
                value.Invoke(_killer);
            }
            else
            {
                _onDead = value;
            }
        }
    }

    private bool _isDead = false;
    public bool IsDead
    {
        get => _isDead;
    }

    private GameObject _killer = null;

    private StatusSystem _statusSystem;

    private void Awake()
    {
        _statusSystem = GetComponent<StatusSystem>();
    }

    public void TakeDamage(float damage, GameObject attacker)
    {
        if (_isDead) return;
        if (damage > 0)
        {
            float origin = _statusSystem.CurrentHealth;
            damage = Mathf.Max(damage, 0);

            _statusSystem.CurrentHealth = Mathf.Max(_statusSystem.CurrentHealth - damage, 0);
            OnDamaged?.Invoke(origin - _statusSystem.CurrentHealth, attacker);

            if (_statusSystem.CurrentHealth == 0)
            {
                Die(attacker);
            }
        }
    }

    public void TakeHeal(float heal, GameObject healer)
    {
        if (_isDead) return;
        if (heal > 0)
        {
            float origin = _statusSystem.CurrentHealth;
            heal = Mathf.Max(heal, 0);

            _statusSystem.CurrentHealth = Mathf.Min(_statusSystem.CurrentHealth + heal, _statusSystem.MaxHealth);

            OnHealed?.Invoke(heal, healer);
        }
    }

    private void Die(GameObject killer)
    {
        if (_isDead) return;
        _killer = killer;
        OnDead?.Invoke(killer);
        _isDead = true;
    }
}
