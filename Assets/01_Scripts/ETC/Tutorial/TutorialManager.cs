using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _wizardText;

    [Header("Base")]
    [SerializeField] private GameObject _playerBaseArrow;
    [SerializeField] private GameObject _enemyBaseArrow;
    [SerializeField] private HealthSystem _enemyBaseHealthSystem;

    [Header("Deck")]
    [SerializeField] private GameObject _deckObject;
    [SerializeField] private GameObject _mercenaryCoinArrow;
    [SerializeField] private GameObject _unitAndSkillArrow;
    [SerializeField] private GameObject _unitArrow;
    [SerializeField] private GameObject _skillArrow;
    [SerializeField] private GameObject _deckGrabArrow;

    [Header("Vr Controller")]
    [SerializeField] private GameObject _gripButton;
    [SerializeField] private GameObject _triggerButton;

    [Header("Wizard")]
    [SerializeField] private Transform _wizardTransform;
    [SerializeField] private Transform _wizardMovePos;

    [Header("Clear")]
    [SerializeField] private GameObject _leftRayInteracter;
    [SerializeField] private GameObject _rightRayInteracter;
    [SerializeField] private GameObject _stageResultUI;


    private void Awake()
    {
        _enemyBaseHealthSystem.OnDead += (_) => StartCoroutine(ClearCoroutine());

        SoundManager.Instance.SoundPlay(SoundManager.Instance.StageSelectSceneBGM, SoundType.BGM);
        StartCoroutine(FadeInOutManager.Instance.FadeOut(null));
        StartCoroutine(TutorialCoroutine());
    }

    private IEnumerator ShowTextAnimation(string text, TextMeshProUGUI tmp, float startWaitTime = 0, float intervalTime = 0.1f, float endWaitTime = 3, GameObject activeObject = null)
    {
        yield return new WaitForSeconds(startWaitTime);
        tmp.text = "";
        activeObject?.SetActive(true);

        for (int i = 0; i < text.Length; i++)
        {
            tmp.text += text[i];
            yield return new WaitForSeconds(intervalTime);
        }

        yield return new WaitForSeconds(endWaitTime);
        tmp.text = "";
        activeObject?.SetActive(false);

        yield break;
    }

    private IEnumerator TutorialCoroutine()
    {
        yield return new WaitForSeconds(2.5f);

        string text1 = "반갑습니다.\n영주님의 자리를 대신하여,\n용변단을 이끌 수 있도록\n도와드리겠습니다.";
        StartCoroutine(ShowTextAnimation(text1, _wizardText));
        yield return new WaitForSeconds(10);

        string text2 = "먼저 왼쪽에 보이는\n성이 당신이 지켜야할\n아군 기지입니다.";
        StartCoroutine(ShowTextAnimation(text2, _wizardText, 0, 0.1f, 5, _playerBaseArrow));
        yield return new WaitForSeconds(9);

        string text3 = "오른쪽에 보이는\n성은 당신이 공격해야할\n적군 기지입니다.";
        StartCoroutine(ShowTextAnimation(text3, _wizardText, 0, 0.1f, 5, _enemyBaseArrow));
        yield return new WaitForSeconds(9);

        string text4 = "그 다음은 덱에 대해서\n설명드리겠습니다.";
        StartCoroutine(ShowTextAnimation(text4, _wizardText));
        yield return new WaitForSeconds(7);

        _deckObject.SetActive(true);
        string text5 = "왼쪽에 보이는\n오브젝트가 덱입니다.";
        StartCoroutine(ShowTextAnimation(text5, _wizardText));
        yield return new WaitForSeconds(8);

        string text6 = "덱을 통해 유닛과 스킬을\n소환하여 적군 기지를\n공격할 수 있습니다.";
        StartCoroutine(ShowTextAnimation(text6, _wizardText));
        yield return new WaitForSeconds(10);

        string text7 = "덱 상단에는 현재 보유중인\n용병 주화가 표시됩니다.";
        StartCoroutine(ShowTextAnimation(text7, _wizardText, activeObject: _mercenaryCoinArrow));
        yield return new WaitForSeconds(9);

        string text8 = "덱의 가운데에는\n선택한 유닛과 스킬이\n표시됩니다.";
        StartCoroutine(ShowTextAnimation(text8, _wizardText, activeObject: _unitAndSkillArrow));
        yield return new WaitForSeconds(9);

        string text9 = "유닛은 직접 움직이고\n적과 싸울 수 있으며\n고유한 스킬을 사용합니다.";
        StartCoroutine(ShowTextAnimation(text9, _wizardText, activeObject: _unitArrow));
        yield return new WaitForSeconds(9);

        string text10 = "스킬은 아군 유닛에게\n 이로운 효과를 주거나,\n 적군 유닛에게\n해로운 효과를 줄 수 있습니다.";
        StartCoroutine(ShowTextAnimation(text10, _wizardText, activeObject: _skillArrow));
        yield return new WaitForSeconds(10);

        string text11 = "마지막으로 덱 하단에\n이펙트를 잡아 덱 오브젝트를\n움직일 수 있습니다.";
        StartCoroutine(ShowTextAnimation(text11, _wizardText, activeObject: _deckGrabArrow));
        yield return new WaitForSeconds(10);

        _gripButton.SetActive(true);

        string text12 = "VR 컨트롤러의 Grip 버튼을 눌러 이펙트를 잡아보세요.";
        StartCoroutine(ShowTextAnimation(text12, _wizardText, endWaitTime:5));
        yield return new WaitForSeconds(12);

        string text13 = "덱을 잡은 손의 반대손으로\nGrip 버튼을 눌러\n슬라임 유닛을 잡아보세요.";
        StartCoroutine(ShowTextAnimation(text13, _wizardText, endWaitTime:5));
        yield return new WaitForSeconds(13);

        _gripButton.SetActive(false);

        _triggerButton.SetActive(true);

        string text14 = "Trigger 버튼을 눌러\n슬라임 유닛을 놓을 수 있습니다.";
        StartCoroutine(ShowTextAnimation(text14, _wizardText, endWaitTime:5));
        yield return new WaitForSeconds(12);

        string text15 = "유닛과 스킬을 더욱 멀리\n던지고 싶다면 팔을 휘두르면서\n마지막에 Trigger 버튼을 눌러\n유닛과 스킬을 놓아보세요.";
        StartCoroutine(ShowTextAnimation(text15, _wizardText, endWaitTime:6));
        yield return new WaitForSeconds(15);

        _triggerButton.SetActive(false);

        StartCoroutine(WizardMoveCoroutine());
        while (_wizardTransform.position != _wizardMovePos.position)
        {
            _wizardTransform.position = Vector3.MoveTowards(_wizardTransform.position, _wizardMovePos.position, Time.deltaTime * 6);
            yield return null;
        }

        string text16 = "이제 유닛과 스킬을 활용하여\n적군 기지를 파괴해보세요!";
        StartCoroutine(ShowTextAnimation(text16, _wizardText));
        yield return new WaitForSeconds(10);

        yield break;
    }

    private IEnumerator WizardMoveCoroutine()
    {
        for(int i=185; i<240; i++)
        {
            _wizardTransform.localEulerAngles = new Vector3(0, i, 0);
            yield return null;
        }

        yield break;
    }

    private IEnumerator ClearCoroutine()
    {
        _leftRayInteracter.SetActive(true);
        _rightRayInteracter.SetActive(true);
        _stageResultUI.SetActive(true);

        string text1 = "축하합니다!\n적군 기지를 파괴하셨습니다.";
        StartCoroutine(ShowTextAnimation(text1, _wizardText));
        yield return new WaitForSeconds(8);

        string text2 = "스테이지를 클리어하게 되면\nVR 컨트롤러의 레이저가\n활성화 됩니다.";
        StartCoroutine(ShowTextAnimation(text2 , _wizardText, endWaitTime:5));
        yield return new WaitForSeconds(11);

        string text3 = "Trigger 버튼을 눌러\nVR 컨트롤러의 레이저가 가리키는\nUI와 상호작용할 수 있습니다.";
        StartCoroutine(ShowTextAnimation(text3 , _wizardText, endWaitTime:8));
        yield return new WaitForSeconds(15);

        string text4 = "\'튜토리얼 마침\' 버튼을 눌러\n튜토리얼을 끝낼 수 있습니다.\n용병단장님의 성공을 바랍니다!";
        StartCoroutine(ShowTextAnimation(text4 , _wizardText, endWaitTime:100));

        yield break;
    }

    public void StartGame()
    {
        DeckManager.EquipCardDatas = new CardData[9];
        StartCoroutine(FadeInOutManager.Instance.FadeIn(() => SceneManager.LoadScene("Stage Select Scene")));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartGame();
        }
    }
}
