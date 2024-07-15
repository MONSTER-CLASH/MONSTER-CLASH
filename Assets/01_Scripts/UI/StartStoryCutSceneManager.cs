using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class StartStoryCutSceneManager : MonoBehaviour
{
    [SerializeField] private Transform _xrOrigin;
    [SerializeField] private GameObject _titleImage;

    [Header("Mercenary Pub")]
    [SerializeField] private TextMeshProUGUI _playerText;
    [SerializeField] private GameObject _evilMageTextObj;
    [SerializeField] private TextMeshProUGUI _evilMageText;
    [SerializeField] private GameObject _crystalSphere;

    [Header("Stage Map")]
    [SerializeField] private Transform _stageMapPos;
    [SerializeField] private Animator _demonKingAnime;
    [SerializeField] private Transform _demonKingMoveTarget;

    [Header("Mercenary Pub 2")]
    [SerializeField] private Transform _mercenaryPub2Pos;
    [SerializeField] private GameObject _evilMageTextObj2;
    [SerializeField] private TextMeshProUGUI _evilMageText2;
    [SerializeField] private PlayableDirector _evilMage2PD;

    private void Awake()
    {
        StartCoroutine(FadeInOutManager.Instance.FadeOut(null));
        StartCoroutine(PlayerTextAnimation1());
    }

    private IEnumerator ShowTextAnimation(string text, TextMeshProUGUI tmp, float startWaitTime = 0, float intervalTime = 0.1f, float endWaitTime = 5)
    {
        yield return new WaitForSeconds(startWaitTime);
        tmp.text = "";

        for (int i=0; i<text.Length; i++)
        {
            tmp.text += text[i];
            yield return new WaitForSeconds(intervalTime);
        }

        yield return new WaitForSeconds(endWaitTime);
        tmp.text = "";

        yield break;
    }

    private IEnumerator PlayerTextAnimation1()
    {
        string text1 = "나는 동부 영주의 장남.";
        StartCoroutine(ShowTextAnimation(text1, _playerText, 3, 0.1f, 2));

        yield return new WaitForSeconds(7.5f);

        string text2 = "동생은 아버지를 도와 영지를 관리하는데..";
        StartCoroutine(ShowTextAnimation(text2, _playerText, 0.5f, 0.1f, 3));

        yield return new WaitForSeconds(5.5f);

        string text3 = "나는 술이나 퍼마시고 있다..";
        StartCoroutine(ShowTextAnimation(text3, _playerText, 0.5f, 0.1f, 2));

        yield break;
    }
    
    public void EvilMageFirstTalk()
    {
        StartCoroutine(EvilMageFirstTalkCoroutine());
    }

    private IEnumerator EvilMageFirstTalkCoroutine()
    {
        _evilMageTextObj.SetActive(true);

        string text1 = "큰일 났습니다!";
        StartCoroutine(ShowTextAnimation(text1, _evilMageText, 1.5f, 0.1f, 2));

        yield return new WaitForSeconds(5.5f);

        string text2 = "영주님께서 영지를 순찰하시다가\n마왕에게 습격당하셨다고 합니다!";
        StartCoroutine(ShowTextAnimation(text2, _evilMageText, 0.5f, 0.1f, 4));

        yield return new WaitForSeconds(8);

        string text3 = "말로 설명할 시간이 없으니,\n 이 수정구를 통해 확인해주십시오.";
        StartCoroutine(ShowTextAnimation(text3, _evilMageText, 0.5f, 0.1f, 4));

        yield break;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TouchCrystalSphere();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(MercenaryPubCut2());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            StartGame();
        }
    }

    public void TouchCrystalSphere()
    {
        Action action = () =>
        {
            _crystalSphere.SetActive(false);
            _xrOrigin.position = _stageMapPos.position;
            _xrOrigin.localEulerAngles = new Vector3(0, -90, 0);
            StartCoroutine(StageMapAnimation());
        };

        StartCoroutine(FadeInOutManager.Instance.FadeInWhite(action));
    }

    private IEnumerator StageMapAnimation()
    {
        StartCoroutine(FadeInOutManager.Instance.FadeOutWhite(null));

        yield return new WaitForSeconds(0.75f);

        _demonKingAnime.SetBool("Move", true);
        StartCoroutine(StageMapSound());

        while (_demonKingAnime.transform.position != _demonKingMoveTarget.position)
        {
            _demonKingAnime.transform.position = 
                Vector3.MoveTowards(_demonKingAnime.transform.position, _demonKingMoveTarget.position, Time.deltaTime * 1.5f);
            yield return null;
        }

        _demonKingAnime.SetBool("Move", false);

        yield return new WaitForSeconds(2f);

        _demonKingAnime.SetTrigger("Attack");

        yield return new WaitForSeconds(1.5f);

        SoundManager.Instance.SoundPlay(SoundManager.Instance.DemonKingAttackSound);

        Action action = () =>
        {
            StartCoroutine(MercenaryPubCut2());
        };
        StartCoroutine(FadeInOutManager.Instance.ImmediatelyFadeIn(action, 1.5f));

        yield break;
    }

    private IEnumerator MercenaryPubCut2()
    {
        _xrOrigin.position = _mercenaryPub2Pos.position;
        StartCoroutine(FadeInOutManager.Instance.FadeOut(null));

        _evilMageTextObj2.SetActive(true);
        string text1 = "영주님은 현재 크게 다치신 상태입니다.";
        StartCoroutine(ShowTextAnimation(text1, _evilMageText2, 2, 0.1f, 3));

        yield return new WaitForSeconds(7);

        string text2 = "영주님께서 남기신 말입니다.";
        StartCoroutine(ShowTextAnimation(text2, _evilMageText2, 0.5f, 0.1f, 2.5f));
        yield return new WaitForSeconds(5);

        string text3 = "\'내 첫째 아들아.\n 마왕 때문에 지금 영지에 돈이 없다.\'";
        StartCoroutine(ShowTextAnimation(text3, _evilMageText2, 0.5f, 0.1f, 3));
        yield return new WaitForSeconds(8f);

        string text4 = "\'둘째는 영지를 관리하고 있으니,\n 너가 영지의 돈을 벌어다주렴.\'";
        StartCoroutine(ShowTextAnimation(text4, _evilMageText2, 0.5f, 0.1f, 3));
        yield return new WaitForSeconds(8);

        string text5 = "마지막으로.. 영주님께서 남기신 검입니다.\n이걸 챙겨주시길..";
        StartCoroutine(ShowTextAnimation(text5, _evilMageText2, 0.5f, 0.1f, 50));

        yield return new WaitForSeconds(3);
        _evilMage2PD.Play();

        yield break;
    }

    private IEnumerator StageMapSound()
    {
        for (int i=0; i<9; i++)
        {
            SoundManager.Instance.SoundPlay(SoundManager.Instance.DemonKingWalkSound);
            yield return new WaitForSeconds(0.95f);
        }

        yield break;
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        StartCoroutine(FadeInOutManager.Instance.FadeIn(null));

        yield return new WaitForSeconds(1.5f);

        _titleImage.SetActive(true);

        yield return new WaitForSeconds(0.25f);

        SceneManager.LoadScene("Stage Select Scene");

        yield break;
    }
}
