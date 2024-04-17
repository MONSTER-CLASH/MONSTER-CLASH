using UnityEngine;

public abstract class SkillData : ScriptableObject
{
    [Space()]
    public string SkillName;
    public Sprite SkillImage;
    public GameObject SkillPrefab;
    public bool HasSkill;

    public abstract string GetSkillDescription();
}
