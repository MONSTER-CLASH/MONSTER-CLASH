using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipSkillItem : MonoBehaviour
{
    public SkillData SkillData;

    [SerializeField] private Image _skillImage;
    [SerializeField] private TextMeshProUGUI _skillNameText;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(DeckManager.Instance.EquipSkill);
    }

    public void UpdateEquipSkillData()
    {
        _skillImage.sprite = SkillData ? SkillData.SkillImage : null;
        _skillNameText.text = SkillData ? SkillData.SkillName : "";
    }
}
