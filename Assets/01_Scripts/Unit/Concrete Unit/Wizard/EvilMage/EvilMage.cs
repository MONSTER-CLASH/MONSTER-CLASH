using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMage : UnitController
{
    [SerializeField] private EvilMageCardData _evilMageCardData;
    [SerializeField] private GameObject _evilMageSkillPrefab;
    [SerializeField] private Transform _attackProjectileSpawnPos;
    [SerializeField] private GameObject _attackProjectilePrefab;

    protected override void HandleAttack()
    {
        if (_attackTarget)
        {
            GameObject ap = Instantiate(_attackProjectilePrefab, _attackProjectileSpawnPos.position, Quaternion.identity);
            ap.GetComponent<AttackableProjectile>().SetProjectileData(gameObject, _attackTarget, _unitStatusSystem.AttackDamage, _unitStatusSystem.AttackRange);
        }
    }

    protected override void HandleSkill()
    {
        if (_canUseSkill)
        {
            string enemyLayer = "";
            if (gameObject.layer == LayerMask.NameToLayer("Player")) enemyLayer = "Enemy";
            else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) enemyLayer = "Player";

            Vector3 skillSpawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject skill = Instantiate(_evilMageSkillPrefab, skillSpawnPos, Quaternion.identity);
            skill.transform.forward = transform.forward;
            skill.GetComponent<EvilMageSkill>().SetEvilMageSkillData(gameObject, enemyLayer,
                _evilMageCardData.SkillHitDamage, _evilMageCardData.SkillSplashDamage, _evilMageCardData.SkillStunTime, _unitStatusSystem.AttackRange);

            _skillCool = Time.time + _evilMageCardData.SkillCoolTime;
        }
    }
}
