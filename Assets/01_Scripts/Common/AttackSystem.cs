using System;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    /// <summary>
    /// float : 가해진 최종 대미지, GameObject : 피해자
    /// </summary>
    public Action<float, GameObject> OnAttackHitted;
    /// <summary>
    /// GameObject : 피해자
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
