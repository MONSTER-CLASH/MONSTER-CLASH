using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    /// <summary>
    /// float : 받은 최종 대미지, GameObject : 공격자
    /// </summary>
    public Action<float, GameObject> OnDamaged;
    /// <summary>
    /// float : 받은 최종 힐량, GameObject : 치유자
    /// </summary>
    public Action<float, GameObject> OnHealed;
    private Action<GameObject> _onDead;
    /// <summary>
    /// GameObject : 처치자
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
