using UnityEngine;

[CreateAssetMenu(fileName = "Test Skill Data", menuName = "Scriptable Object/Skill Datas/Test Skill Data")]
public class TestSkillData : SkillData
{
    public override string GetSkillDescription()
    {
        return "파이어 볼을 날려 범위내의 적에게 50의 피해를 입힙니다.";
    }
}
