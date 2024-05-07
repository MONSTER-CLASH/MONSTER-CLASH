using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveSkillInfo : MonoBehaviour
{
    [Header("Upper UI Elements")]
    [SerializeField] private Image _skillImage;
    [SerializeField] private TextMeshProUGUI _skillNameText;

    [Header("Lower UI Elements")]
    [SerializeField] private TextMeshProUGUI _skillDescriptionText;

    private void Awake()
    {
        transform.position = transform.parent.parent.parent.parent.position;
    }

    public void ShowHaveSkillInfo(SkillData skillData)
    {
        _skillImage.sprite = skillData.SkillImage;

        _skillNameText.text = skillData.SkillName;

        _skillDescriptionText.text = skillData.GetSkillDescription();
    }
}
