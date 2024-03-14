using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitStatusSystem))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(AttackSystem))]
public abstract class UnitController : MonoBehaviour
{
    protected UnitStatusSystem _unitStatusSystem;
    private HealthSystem _healthSystem;
    protected AttackSystem _attackSystem;

    private NavMeshAgent _agent;
    private Animator _animator;

    private bool _canAttack => _attackCool < Time.time;
    private float _attackCool;
    protected GameObject _attackTarget;
    private Transform _oppositeBasePos;

    private bool _canMove => _motionStopTime < Time.time;
    private float _motionStopTime;

    private LayerMask _oppositeLayer;


    private void Awake()
    {
        _unitStatusSystem = GetComponent<UnitStatusSystem>();
        _healthSystem = GetComponent<HealthSystem>();

        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        if (gameObject.layer == LayerMask.NameToLayer("Player")) _oppositeLayer = LayerMask.NameToLayer("Enemy");
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) _oppositeLayer = LayerMask.NameToLayer("Player");
        SetOppositeBase();
    }

    private void Start()
    {
        _agent.speed = _unitStatusSystem.MoveSpeed;
    }

    protected void SetOppositeBase()
    {
        if (_oppositeLayer == LayerMask.NameToLayer("Enemy"))
        {
            _oppositeBasePos = GameObject.FindGameObjectWithTag("EnemyBase").transform;
        }
        else if (_oppositeLayer == LayerMask.NameToLayer("Player"))
        {
            _oppositeBasePos = GameObject.FindGameObjectWithTag("PlayerBase").transform;
        }

        if (_oppositeBasePos == null)
        {
            Debug.LogError("Opposite Base is Missing.\nGameObject : " + gameObject.name);
        }
    }

    protected void DetectAttackTarget()
    {
        if (_attackTarget || !_canMove || _healthSystem.IsDead) return;

        List<Collider> enemys = Physics.OverlapSphere(transform.position, _unitStatusSystem.AttackDetectRange, _oppositeLayer).ToList();
        enemys = enemys.OrderByDescending(i => Vector3.Distance(transform.position, i.transform.position)).ToList();
        
        if (enemys.Count > 0)
        {
            _attackTarget = enemys[0].gameObject;
        }

    }

    protected void Attack()
    {
        if (!_canAttack || !_attackTarget || _healthSystem.IsDead) return;

        Collider[] enemys = Physics.OverlapSphere(transform.position, _unitStatusSystem.AttackRange, _oppositeLayer);

        if (enemys.Contains(_attackTarget.GetComponent<Collider>()))
        {
            HandleAttack();
            _attackCool = Time.time + (1f / _unitStatusSystem.AttackSpeed);
            //StartCoroutine(SetMotionStopTime());
        }
    }

    protected abstract void HandleAttack();

    private IEnumerator SetMotionStopTime()
    {
        yield return null;
        _motionStopTime = Time.time + _animator.GetNextAnimatorClipInfo(0).Length;
    }

    protected void Move()
    {
        _agent.isStopped = !_canMove || (!_attackTarget && !_oppositeBasePos) || _healthSystem.IsDead;

        if (_attackTarget)
        {
            _agent.SetDestination(_attackTarget.transform.position);
        }
        else if (_oppositeBasePos)
        {
            _agent.SetDestination(_oppositeBasePos.transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        if (_unitStatusSystem)
        {
            Gizmos.color = new Color(0, 1, 0, 0.25f);
            Gizmos.DrawSphere(transform.position, _unitStatusSystem.AttackDetectRange);

            Gizmos.color = new Color(1, 0, 0, 0.25f);
            Gizmos.DrawSphere(transform.position, _unitStatusSystem.AttackRange);
        }
    }
}
