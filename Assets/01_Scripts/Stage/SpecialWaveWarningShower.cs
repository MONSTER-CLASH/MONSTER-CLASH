using System.Collections;
using UnityEngine;

public class SpecialWaveWarningShower : MonoBehaviour
{
    public static SpecialWaveWarningShower Instance;

    [SerializeField] private GameObject _warningUI;
    [SerializeField] private Light _warningLight;

    private bool _isShowedWarning = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowWarning()
    {
        if (!_isShowedWarning)
        {
            StartCoroutine(ShowWarningCoroutine());
            _isShowedWarning = true;
        }
    }

    private IEnumerator ShowWarningCoroutine()
    {
        _warningUI.SetActive(true);
        _warningLight.gameObject.SetActive(true);

        for (int i=0; i<3; i++)
        {
            while (_warningLight.intensity < 3.5f)
            {
                _warningLight.intensity += Time.deltaTime * 7f;
                yield return null;
            }

            yield return new WaitForSeconds(0.5f);

            while (_warningLight.intensity > 0)
            {
                _warningLight.intensity -= Time.deltaTime * 7f;
                yield return null;
            }
        }

        _warningUI.SetActive(false);
        _warningLight.gameObject.SetActive(false);

        yield break;
    }
}
