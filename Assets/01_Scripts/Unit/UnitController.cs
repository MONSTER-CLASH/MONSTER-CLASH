using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnitStatusSystem))]
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(AttackSystem))]
public class UnitController : MonoBehaviour
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
        _attackSystem = GetComponent<AttackSystem>();

        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();

        SetOppositeBase();

        _healthSystem.OnDead += HandleDie;
    }

    private void Start()
    {
        _agent.speed = _unitStatusSystem.MoveSpeed;
    }

    protected virtual void Update()
    {
        Move();
        DetectAttackTarget();
        Attack();
    }

    protected void SetOppositeBase()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player")) _oppositeLayer = LayerMask.GetMask("Enemy");
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) _oppositeLayer = LayerMask.GetMask("Player");

        if (_oppositeLayer == LayerMask.GetMask("Enemy"))
        {
            _oppositeBasePos = GameObject.FindGameObjectWithTag("EnemyBase").transform;
        }
        else if (_oppositeLayer == LayerMask.GetMask("Player"))
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
        if (_attackTarget && _attackTarget.GetComponent<HealthSystem>().IsDead)
        {
            _attackTarget = null;
        }

        if (_attackTarget || !_canMove || _healthSystem.IsDead) return;

        List<Collider> enemys = Physics.OverlapSphere(transform.position, _unitStatusSystem.AttackDetectRange, _oppositeLayer).ToList();
        enemys = enemys.OrderByDescending(i => Vector3.Distance(transform.position, i.transform.position)).ToList();
        
        if (enemys.Count > 0)
        {
            for (int i=0; i <enemys.Count; i++)
            {
                if (!enemys[i].GetComponent<HealthSystem>().IsDead)
                {
                    _attackTarget = enemys[i].gameObject;
                    return;
                }
            }
        }
    }

    protected void Attack()
    {
        if (!_canAttack || !_attackTarget || _healthSystem.IsDead) return;

        Collider[] enemys = Physics.OverlapSphere(transform.position, _unitStatusSystem.AttackRange, _oppositeLayer);

        if (enemys.Contains(_attackTarget.GetComponent<Collider>()))
        {
            _attackCool = Time.time + (1f / _unitStatusSystem.AttackSpeed);
            StartCoroutine(SetMotionStopTime());
        }
    }

    protected virtual void HandleAttack()
    {
        if (_attackTarget)
        {
            _attackSystem.SendDamage(_attackTarget, _unitStatusSystem.AttackDamage, gameObject);
        }
    }

    private IEnumerator SetMotionStopTime()
    {
        _animator.SetTrigger("Attack");
        yield return null;
        _motionStopTime = Time.time + _animator.GetCurrentAnimatorStateInfo(0).length;
    }

    protected void Move()
    {
        List<Collider> enemys = Physics.OverlapSphere(transform.position, _unitStatusSystem.AttackRange, _oppositeLayer).ToList();
        bool isEnemyExistInAttackRange = enemys.Contains(_attackTarget?.GetComponent<Collider>());

        _agent.isStopped = !_canMove || (_oppositeBasePos.GetComponent<HealthSystem>().IsDead) || _healthSystem.IsDead || isEnemyExistInAttackRange;
        _animator.SetInteger("Move", _canMove ? 1 : 0);

        if (_attackTarget)
        {
            _agent.SetDestination(_attackTarget.transform.position);
        }
        else if (_oppositeBasePos)
        {
            _agent.SetDestination(_oppositeBasePos.transform.position);
        }
    }

    private void HandleDie(GameObject killer)
    {
        StartCoroutine(DieCoroutine(killer));
    }

    protected virtual IEnumerator DieCoroutine(GameObject killer)
    {
        _animator.SetTrigger("Die");

        yield return null;
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);

        yield break;
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
