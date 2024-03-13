using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitStatusSystem))]
[RequireComponent(typeof(HealthSystem))]
public abstract class UnitController : MonoBehaviour
{
    private UnitStatusSystem _unitStatusSystem;
    private HealthSystem _healthSystem;

    private NavMeshAgent _agent;
    private Animator _animator;

    private bool _canAttack => _attackCool < Time.time;
    private float _attackCool;
    private GameObject _attackTarget;

    private bool _canMove => _motionStopTime < Time.time;
    private float _motionStopTime;


    private void Awake()
    {
        _unitStatusSystem = GetComponent<UnitStatusSystem>();
        _healthSystem = GetComponent<HealthSystem>();

        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    protected void DetectEnemyBase()
    {
        GameObject enemyBase = null;
        if (gameObject.layer == LayerMask.NameToLayer("Player")) enemyBase = GameObject.FindGameObjectWithTag("EnemyBase");
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) enemyBase = GameObject.FindGameObjectWithTag("PlayerBase");

        if (enemyBase != null)
        {
            _agent.SetDestination(enemyBase.transform.position);
        }
    }

    protected void DetectAttackTarget()
    {
        if (_attackTarget || _healthSystem.IsDead) return;

        string checkLayer = null;
        if (gameObject.layer == LayerMask.NameToLayer("Player")) checkLayer = "Enemy";
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) checkLayer = "Player";

        List<Collider> enemys = Physics.OverlapSphere(transform.position, _unitStatusSystem.AttackDetectRange, 1 << LayerMask.NameToLayer(checkLayer)).ToList();
        enemys = enemys.OrderByDescending(i => Vector3.Distance(transform.position, i.transform.position)).ToList();
        
        if (enemys.Count > 0)
        {
            _attackTarget = enemys[0].gameObject;
        }

    }

    protected void Attack()
    {
        if (!_canAttack || !_attackTarget || _healthSystem.IsDead) return;

        string checkLayer = null;
        if (gameObject.layer == LayerMask.NameToLayer("Player")) checkLayer = "Enemy";
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) checkLayer = "Player";

        Collider[] enemys = Physics.OverlapSphere(transform.position, _unitStatusSystem.AttackRange, 1 << LayerMask.NameToLayer(checkLayer));

        if (enemys.Contains(_attackTarget.GetComponent<Collider>()))
        {
            HandleAttack();
            _attackCool = Time.time + (1f / _unitStatusSystem.AttackSpeed);
        }
    }

    private IEnumerator SetMotionStopTime()
    {
        yield return null;
        _motionStopTime = Time.time + _animator.GetNextAnimatorClipInfo(0).Length;
    }

    protected void Move()
    {

    }

    protected abstract void HandleAttack();
}
