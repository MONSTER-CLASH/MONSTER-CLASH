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
            GameObject go = Instantiate(_skeletonCardData.SkillVFX, transform);
            go.transform.localPosition = Vector3.zero;
            Destroy(go, _skeletonCardData.SkillDurationTime);


            _buffSystem.AddBuff(new AttackDamageIncreaseBuff(
                InDecreaseType.Coefficient, _skeletonCardData.SkillIncreaseCoefficient, _skeletonCardData.SkillDurationTime));

            _skillCool = Time.time + _skeletonCardData.SkillCoolTime;
        }
    }
}
