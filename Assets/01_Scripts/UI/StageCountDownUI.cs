using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageCountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countDownText;

    private void Awake()
    {
        StartCoroutine(CountDownCoroutine());
    }

    private IEnumerator CountDownCoroutine()
    {
        for (int i=3; i>0; i--)
        {
            _countDownText.text = i.ToString();

            yield return new WaitForSeconds(1);
        }

        _countDownText.text = "스테이지 시작!";
        yield return new WaitForSeconds(1.5f);

        _countDownText.text = "";

        yield break;
    }
}
