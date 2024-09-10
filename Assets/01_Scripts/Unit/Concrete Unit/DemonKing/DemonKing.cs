using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonKing : UnitController
{
    [SerializeField] private GameObject _attackVFXPrefab;
    [SerializeField] private GameObject _skillProjectilePrefab;
    [SerializeField] private DemonKingCardData _demonKingCardData;

    protected override void HandleAttack()
    {
        if (_attackTarget)
        {
            transform.LookAt(_attackTarget.transform);
            Destroy(Instantiate(_attackVFXPrefab, _attackTarget.transform), 5);

            Collider[] enemys = Physics.OverlapSphere(_attackTarget.transform.position, 1.5f, _oppositeLayer);
            for (int i=0; i<enemys.Length; i++)
            {
                enemys[i].GetComponent<HealthSystem>().TakeDamage(_unitStatusSystem.AttackDamage, gameObject);
            }
        }
    }

    protected override void HandleSkill()
    {
        if (_canUseSkill && _attackTarget)
        {
            StartCoroutine(HandleSkillCoroutine());
            _skillCool = Time.time + _demonKingCardData.SkillCoolTime;
        }
    }

    private IEnumerator HandleSkillCoroutine()
    {
        transform.LookAt(_attackTarget.transform);
        _attackTarget = null;
        _animator.SetTrigger("Skill");
        StartCoroutine(SetMotionStopTime());
        yield return new WaitForSeconds(0.4f);

        string enemyLayer = "";
        if (gameObject.layer == LayerMask.NameToLayer("Player")) enemyLayer = "Enemy";
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) enemyLayer = "Player";

        GameObject skill = Instantiate(_skillProjectilePrefab, transform.position + new Vector3(0,1.5f,0) + transform.forward, Quaternion.identity);
        skill.GetComponent<DemonKingSkillProjectile>().SetDemonKingSkillData(gameObject, enemyLayer, _demonKingCardData.SkillDamage, _unitStatusSystem.AttackDetectRange * 1.25f);
        skill.transform.forward = transform.forward;

        yield break;
    }
}
