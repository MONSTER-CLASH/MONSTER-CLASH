using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    /// <summary>
    /// float : ������ ���� �����, GameObject : ������
    /// </summary>
    public Action<float, GameObject> OnAttackHitted;
    /// <summary>
    /// GameObject : ������
    /// </summary>
    public Action<GameObject> OnKilled;

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
