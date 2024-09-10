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

    private LayerMask _oppositeLayer;

    private void Awake()
    {
        _baseStatusSystem = GetComponent<BaseStatusSystem>();
        _healthSystem = GetComponent<HealthSystem>();

        if (gameObject.layer == LayerMask.NameToLayer("Player")) _oppositeLayer = LayerMask.GetMask("Enemy");
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) _oppositeLayer = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (!_canAttack || _healthSystem.IsDead || StageManager.Instance.IsStageEnd) return;

        Collider[] enemys = Physics.OverlapSphere(transform.position, _baseStatusSystem.AttackRange, _oppositeLayer);
        enemys = enemys.ToList().OrderByDescending(i => Vector3.Distance(transform.position, i.transform.position)).ToArray();
        
        for (int i=0; i<enemys.Length; i++)
        {
            if (!enemys[i].GetComponent<HealthSystem>().IsDead)
            {
                AttackableProjectile projectile =
                    Instantiate(_attackProjectilePrefab, attackProjectileSpawnPos.position, Quaternion.identity).GetComponent<AttackableProjectile>();

                projectile.SetProjectileData(gameObject, enemys[i].gameObject, _baseStatusSystem.AttackDamage, _baseStatusSystem.AttackRange);

                _attackCool = Time.time + (1f / _baseStatusSystem.AttackSpeed);

                return;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (_baseStatusSystem)
        {
            Gizmos.color = new Color(1, 0, 0, 0.25f);
            Gizmos.DrawSphere(transform.position, _baseStatusSystem.AttackRange);
        }
    }
}
