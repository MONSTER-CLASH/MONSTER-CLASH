using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMage : UnitController
{
    [SerializeField] private EvilMageCardData _evilMageCardData;
    [SerializeField] private GameObject _evilMageSkillPrefab;
    [SerializeField] private GameObject _evilMageSkillChargePrefab;
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
            StartCoroutine(EvilMageSkillCoroutine());
            _skillCool = Time.time + _evilMageCardData.SkillCoolTime;
        }
    }

    private IEnumerator EvilMageSkillCoroutine()
    {
        transform.LookAt(_attackTarget.transform);
        _attackTarget = null;
        _animator.SetTrigger("Skill");
        StartCoroutine(SetMotionStopTime());
        yield return null;
        _attackTarget = null;

        GameObject ch = Instantiate(_evilMageSkillChargePrefab, _attackProjectileSpawnPos);
        ch.transform.localPosition = Vector3.zero;
        Destroy(ch, 5);

        yield return new WaitForSeconds(1.35f);

        string enemyLayer = "";
        if (gameObject.layer == LayerMask.NameToLayer("Player")) enemyLayer = "Enemy";
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) enemyLayer = "Player";

        GameObject skill = Instantiate(_evilMageSkillPrefab, _attackProjectileSpawnPos.position, Quaternion.identity);
        skill.transform.forward = transform.forward;
        skill.GetComponent<EvilMageSkill>().SetEvilMageSkillData(gameObject, enemyLayer,
            _evilMageCardData.SkillHitDamage, _evilMageCardData.SkillSplashDamage, _evilMageCardData.SkillStunTime, _unitStatusSystem.AttackRange);

        yield break;
    }
}
