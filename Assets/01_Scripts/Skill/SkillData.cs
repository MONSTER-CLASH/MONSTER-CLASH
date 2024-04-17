using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/Unit Data")]
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
