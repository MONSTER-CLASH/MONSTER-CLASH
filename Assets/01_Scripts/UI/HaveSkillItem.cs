using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HaveSkillItem : MonoBehaviour
{
    [SerializeField] private GameObject _haveSkillInfoLayer;
    [SerializeField] private Image _skillImage;
    [SerializeField] private TextMeshProUGUI _skillNameText;

    private SkillData _skillData;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ShowSkillInfoLayer);
    }

    public void SetItemData(SkillData skillData)
    {
        _skillData = skillData;

        //_skillImage.sprite = _skillData.SkillImage;
        _skillNameText.text = _skillData.SkillName;
    }

    public void ShowSkillInfoLayer()
    {

    }
}
