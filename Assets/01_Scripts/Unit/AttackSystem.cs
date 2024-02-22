using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public Action<float, GameObject> OnAttackHitted;
    public Action<GameObject> OnKilled;

    private StatusSystem _statusSystem;

    private void Awake()
    {
        _statusSystem = GetComponent<StatusSystem>();
    }

    public void SendDamage(GameObject target, float damage)
    {
        HealthSystem healthSystem = target.GetComponent<HealthSystem>();

        Action<float, GameObject> onHitted = (finalDamage, _) => { OnAttackHitted?.Invoke(finalDamage, target); };
        Action<GameObject> onKilled = (_) => { OnKilled?.Invoke(target); };

        if (healthSystem != null)
        {
            healthSystem.OnDamaged += onHitted;
            healthSystem.OnDead += onKilled;
        }

        healthSystem.TakeDamage(damage, gameObject);

        if (healthSystem != null)
        {
            healthSystem.OnDamaged -= onHitted;
            healthSystem.OnDead -= onKilled;
        }
    }
}
