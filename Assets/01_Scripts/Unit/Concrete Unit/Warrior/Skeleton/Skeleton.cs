using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : UnitController
{
    [SerializeField] private SkeletonCardData _skeletonCardData;

    protected override void HandleSkill()
    {
        if (_canUseSkill)
        {
            _buffSystem.AddBuff(new AttackDamageIncreaseBuff(
                InDecreaseType.Coefficient, _skeletonCardData.SkillIncreaseCoefficient, _skeletonCardData.SkillDurationTime));

            _animator.SetTrigger("Skill");
            StartCoroutine(SetMotionStopTime());

            _skillCool = Time.time + _skeletonCardData.SkillCoolTime;
        }
    }
}
