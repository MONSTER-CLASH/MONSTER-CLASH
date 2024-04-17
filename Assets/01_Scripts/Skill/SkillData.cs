using UnityEngine;

[CreateAssetMenu(fileName = "Skill Data", menuName = "Scriptable Object/Skill Data")]
public abstract class SkillData : ScriptableObject
{
    [Space()]
    public string SkillName;
    public int SkillLevel;
    public Sprite SkillImage;
    public GameObject SkillPrefab;

    [Space()]
    public string SkillDescription;

    public abstract string GetSkillDescription();
}
