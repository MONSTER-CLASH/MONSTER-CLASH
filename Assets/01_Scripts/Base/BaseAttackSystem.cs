using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BaseStatusSystem))]
[RequireComponent(typeof(HealthSystem))]
public class BaseAttackSystem : MonoBehaviour
{
    [SerializeField] private GameObject _attackProjectilePrefab;
    [SerializeField] private Transform attackProjectileSpawnPos;
    private float _attackCool;
    private bool _canAttack => _attackCool <= Time.time;

    private BaseStatusSystem _baseStatusSystem;
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _baseStatusSystem = GetComponent<BaseStatusSystem>();
        _healthSystem = GetComponent<HealthSystem>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (!_canAttack || _healthSystem.IsDead) return;

        string checkLayer = null;
        if (gameObject.layer == LayerMask.NameToLayer("Player")) checkLayer = "Enemy";
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) checkLayer = "Player";

        Collider[] enemys = Physics.OverlapSphere(transform.position, _baseStatusSystem.AttackRange, 1 << LayerMask.NameToLayer(checkLayer));
        enemys = enemys.ToList().OrderByDescending(i => Vector3.Distance(transform.position, i.transform.position)).ToArray();
        
        if (enemys.Length > 0)
        {
            AttackableProjectile projectile =
            Instantiate(_attackProjectilePrefab, attackProjectileSpawnPos.position, Quaternion.identity).GetComponent<AttackableProjectile>();

            projectile.SetProjectileData(gameObject, enemys[0].gameObject, _baseStatusSystem.AttackDamage, _baseStatusSystem.AttackRange);

            _attackCool = Time.time + (1f / _baseStatusSystem.AttackSpeed);
        }

    }
}
