using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : UnitController
{
    [SerializeField] private SlimeCardData _slimeCardData;

    protected override void HandleSkill()
    {
        if (_canUseSkill && _attackTarget && Vector3.Distance(_attackTarget.transform.position, transform.position) <= _slimeCardData.SkillRange)
        {
            Destroy(Instantiate(_slimeCardData.SkillVFX, transform.position, Quaternion.identity), 3);

            LayerMask enemyLayer = 0;
            if (gameObject.layer == LayerMask.NameToLayer("Player")) enemyLayer = LayerMask.GetMask("Enemy");
            else if (gameObject.layer == LayerMask.NameToLayer("Enemy")) enemyLayer = LayerMask.GetMask("Player");

            Collider[] enemys = Physics.OverlapSphere(transform.position, _slimeCardData.SkillRange, enemyLayer);

            foreach (Collider enemy in enemys)
            {
                if (enemy.GetComponent<HealthSystem>() != null)
                {
                    enemy.GetComponent<HealthSystem>().TakeDamage(_unitStatusSystem.AttackDamage * 2, gameObject);
                }
            }

            _skillCool = Time.time + _slimeCardData.SkillCoolTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 0.25f);
        Gizmos.DrawWireSphere(transform.position, _slimeCardData.SkillRange);
    }
}
