using UnityEngine;

public abstract class SkillData : ScriptableObject
{
    [Space()]
    public string SkillName;
    public Sprite SkillImage;
    public bool HasSkill;

    [Space()]
    public GameObject SkillModel;   // ���� �� ������ ��ų �� ������Ʈ
    public GameObject SkillPrefab;  // ���� ��ȯ�� ��ų ������ ������Ʈ
    public float SpawnCoolTime;

    public abstract string GetSkillDescription();
}
