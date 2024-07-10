using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : UnitController
{
    [SerializeField] private DragonCardData _dragonCardData;
    [SerializeField] private Transform _attackProjectileSpawnPos;
    [SerializeField] private GameObject _attackProjectilePrefab;

    protected override void HandleAttack()
    {
        if (_attackTarget)
        {
            transform.LookAt(_attackTarget.transform);
            GameObject ap = Instantiate(_attackProjectilePrefab, _attackProjectileSpawnPos.position, Quaternion.identity);
            ap.GetComponent<AttackableProjectile>().SetProjectileData(gameObject, _attackTarget, _unitStatusSystem.AttackDamage, _unitStatusSystem.AttackRange);
        }
    }

    protected override void HandleSkill()
    {
        if (_canUseSkill && _attackTarget)
        {
            StartCoroutine(DragonSkillCoroutine());
            _skillCool = Time.time + _dragonCardData.SkillCoolTime;
        }
    }

    private IEnumerator DragonSkillCoroutine()
    {
        transform.LookAt(_attackTarget.transform);
        _attackTarget = null;
        _animator.SetTrigger("Skill");
        StartCoroutine(SetMotionStopTime());
        yield return null;
        _attackTarget = null;

        yield return new WaitForSeconds(1.75f);

        string enemyLayer = "";
        if (gameObject.layer == LayerMask.NameToLayer("Player")) enemyLayer = "Enemy";
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) enemyLayer = "Player";

        GameObject skill = Instantiate(_dragonCardData.SkillVFX, transform.position + new Vector3(0,0.225f,0), Quaternion.identity);

        skill.transform.forward = transform.forward;
        skill.GetComponent<DragonSkill>().SetDragonSkillData(_dragonCardData.SkillTickDamage, enemyLayer, gameObject);

        yield break;
    }
}
