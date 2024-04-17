using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [SerializeField] private SkillData[] _skillDatas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("SkillManager Instance Error\nGameObject : " + gameObject.name);
        }
        DontDestroyOnLoad(gameObject);
    }

    public SkillData[] GetHasSkillDatas()
    {
        List<SkillData> skillDatas = new List<SkillData>();

        for (int i=0; i<_skillDatas.Length; i++)
        {
            if (_skillDatas[i].HasSkill)
            {
                skillDatas.Add(_skillDatas[i]);
            }
        }

        return skillDatas.ToArray();
    }
}
