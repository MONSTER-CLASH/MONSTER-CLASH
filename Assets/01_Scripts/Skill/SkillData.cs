using UnityEngine;

public abstract class SkillData : ScriptableObject
{
    [Space()]
    public string SkillName;
    public Sprite SkillImage;
    public bool HasSkill;

    [Space()]
    public GameObject SkillModel;   // 날라갈 때 보여질 스킬 모델 오브젝트
    public GameObject SkillPrefab;  // 실제 소환될 스킬 프리팹 오브젝트
    public float SpawnCoolTime;

    public abstract string GetSkillDescription();
}
