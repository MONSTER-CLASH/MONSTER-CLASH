using System;
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

    public void SendDamage(GameObject target, float damage, GameObject attacker)
    {
        HealthSystem healthSystem = target.GetComponent<HealthSystem>();

        Action<float, GameObject> onHitted = (finalDamage, _) => { OnAttackHitted?.Invoke(finalDamage, target); };
        Action<GameObject> onKilled = (_) => { OnKilled?.Invoke(target); };

        if (healthSystem != null)
        {
            healthSystem.OnDamaged += onHitted;
            healthSystem.OnDead += onKilled;
        }

        healthSystem.TakeDamage(damage, attacker);

        if (healthSystem != null)
        {
            healthSystem.OnDamaged -= onHitted;
            healthSystem.OnDead -= onKilled;
        }
    }
}
