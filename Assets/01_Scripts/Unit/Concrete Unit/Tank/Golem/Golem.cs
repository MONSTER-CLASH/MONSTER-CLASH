using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Golem : UnitController
{
    [SerializeField] private GolemCardData _golemCardData;

    protected override void HandleSkill()
    {
        if (_canUseSkill)
        {
            List<Collider> enemys = Physics.OverlapSphere(transform.position, _unitStatusSystem.AttackDetectRange * 2, _oppositeLayer).ToList();
            enemys = enemys.OrderByDescending(i => Vector3.Distance(transform.position, i.transform.position)).ToList();

            for (int i=0; i<enemys.Count; i++)
            {
                if (enemys[i].GetComponent<UnitStatusSystem>())
                {
                    _attackTarget = null;
                    transform.LookAt(enemys[i].transform);

                    enemys[i].GetComponent<BuffSystem>()?.AddBuff(new StunBuff(_golemCardData.SkillStunTime));
                    VFXManager.Instance.InstantiateUnitHitVFX(enemys[i].transform, _golemCardData.SkillHitVFX);
                    StartCoroutine(GolemSkillCoroutine(enemys[i].gameObject));
                    StartCoroutine(GolemSkillAttackVFXCoroutine());

                    _animator.SetTrigger("Skill");
                    StartCoroutine(SetMotionStopTime());

                    _skillCool = Time.time + _golemCardData.SkillCoolTime;

                    break;
                }
            }
        }
    }

    private IEnumerator GolemSkillCoroutine(GameObject target)
    {
        Vector3 pos = transform.position + transform.forward;

        while (target.transform.position != pos)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, pos, _unitStatusSystem.AttackDetectRange * 2.5f * Time.deltaTime);
            yield return null;
        }

        yield break;
    }

    private IEnumerator GolemSkillAttackVFXCoroutine()
    {
        yield return null;
        _attackTarget = null;

        yield return new WaitForSeconds(0.60f);
        Destroy(Instantiate(_golemCardData.SkillAttackVFX, transform.position + transform.forward + new Vector3(0,0.1f,0), Quaternion.identity), 4);

        yield break;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.25f);
        Gizmos.DrawWireSphere(transform.position, _unitStatusSystem.AttackDetectRange * 2);
    }
}
