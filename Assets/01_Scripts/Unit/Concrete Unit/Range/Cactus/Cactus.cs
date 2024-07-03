using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : UnitController
{
    [SerializeField] private CactusCardData _cactusCardData;
    [SerializeField] private GameObject _skillProjectilePrefab;
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
        if (_canUseSkill)
        {
            string enemyLayer = "";
            if (gameObject.layer == LayerMask.NameToLayer("Player")) enemyLayer = "Enemy";
            else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) enemyLayer = "Player";

            for (int i=-2; i<3; i++)
            {
                Vector3 skillSpawnPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                GameObject skill = Instantiate(_skillProjectilePrefab, skillSpawnPos, Quaternion.identity);
                skill.GetComponent<CactusSkillProjectile>().SetCactusSkillData(gameObject, enemyLayer,
                    _cactusCardData.SkillFirstHitDamage, _cactusCardData.SkillLaterHitDamage, _unitStatusSystem.AttackRange);
                skill.transform.forward = transform.forward;

                skill.transform.localEulerAngles =
                    new Vector3(skill.transform.localEulerAngles.x, skill.transform.localEulerAngles.y + i * 10, skill.transform.localEulerAngles.z);
            }

            _skillCool = Time.time + _cactusCardData.SkillCoolTime;
        }
    }
}
