using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackableProjectile : MonoBehaviour
{
    /// <summary>
    /// float : 가해진 최종 대미지, GameObject : 피해자
    /// </summary>
    public Action<float, GameObject> OnAttackHitted;
    /// <summary>
    /// GameObject : 피해자
    /// </summary>
    public Action<GameObject> OnKilled;

    private GameObject _attacker;
    private GameObject _target;
    private float _damage;
    private bool _isTargeted;

    private void FixedUpdate()
    {
        if (_target != null)
        {
            transform.LookAt(_target.transform.position);
        }
        else if (_target == null && _isTargeted)
        {
            Destroy(gameObject);
        }
        
    }

    public void SetProjectileData(GameObject attacker, GameObject target, float damage, float speed)
    {
        _attacker = attacker;
        _target = target;
        _damage = damage;
        _isTargeted = true;

        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }

    private void SendDamage()
    {
        HealthSystem healthSystem = _target.GetComponent<HealthSystem>();

        Action<float, GameObject> onHitted = (finalDamage, _) => { OnAttackHitted?.Invoke(finalDamage, _target); };
        Action<GameObject> onKilled = (_) => { OnKilled?.Invoke(_target); };

        if (healthSystem != null)
        {
            healthSystem.OnDamaged += onHitted;
            healthSystem.OnDead += onKilled;
        }

        healthSystem.TakeDamage(_damage, _attacker);

        if (healthSystem != null)
        {
            healthSystem.OnDamaged -= onHitted;
            healthSystem.OnDead -= onKilled;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_target != null && other.gameObject == _target)
        {
            SendDamage();
            Destroy(gameObject);
        }
    }
}
