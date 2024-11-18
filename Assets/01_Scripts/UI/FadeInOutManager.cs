using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutManager : MonoBehaviour
{
    public static FadeInOutManager Instance;

    private Image _fadeInOutImage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator ImmediatelyFadeIn(Action action, float waitTime)
    {
        if (_fadeInOutImage == null)
        {
            _fadeInOutImage = GameObject.FindGameObjectWithTag("FadeInOutImage").GetComponent<Image>();

            if (_fadeInOutImage == null)
            {
                yield break;
            }
        }

        _fadeInOutImage.gameObject.SetActive(true);
        _fadeInOutImage.color = new Color(0, 0, 0, 1);

        yield return new WaitForSeconds(waitTime);

        action?.Invoke();

        yield break;
    }

    public IEnumerator FadeIn(Action action)
    {
        if (_fadeInOutImage == null)
        {
            _fadeInOutImage = GameObject.FindGameObjectWithTag("FadeInOutImage").GetComponent<Image>();

            if (_fadeInOutImage == null)
            {
                yield break;
            }
        }

        _fadeInOutImage.gameObject.SetActive(true);
        _fadeInOutImage.color = new Color(0, 0, 0, 0);

        while (_fadeInOutImage.color.a < 1)
        {
            _fadeInOutImage.color = new Color(0, 0, 0, _fadeInOutImage.color.a + Time.deltaTime);
            yield return null;
        }

        action?.Invoke();

        yield break;
    }

    public IEnumerator FadeOut(Action action)
    {
        if (_fadeInOutImage == null)
        {
            _fadeInOutImage = GameObject.FindGameObjectWithTag("FadeInOutImage").GetComponent<Image>();

            if (_fadeInOutImage == null)
            {
                yield break;
            }
        }

        _fadeInOutImage.gameObject.SetActive(true);
        _fadeInOutImage.color = new Color(0, 0, 0, 1);

        while (_fadeInOutImage.color.a > 0)
        {
            _fadeInOutImage.color = new Color(0, 0, 0, _fadeInOutImage.color.a - Time.deltaTime);
            yield return null;
        }

        action?.Invoke();
        _fadeInOutImage.gameObject.SetActive(false);

        yield break;
    }

    public IEnumerator FadeInWhite(Action action)
    {
        if (_fadeInOutImage == null)
        {
            _fadeInOutImage = GameObject.FindGameObjectWithTag("FadeInOutImage").GetComponent<Image>();

            if (_fadeInOutImage == null)
            {
                yield break;
            }
        }

        _fadeInOutImage.gameObject.SetActive(true);
        _fadeInOutImage.color = new Color(1, 1, 1, 0);

        while (_fadeInOutImage.color.a < 1)
        {
            _fadeInOutImage.color = new Color(1, 1, 1, _fadeInOutImage.color.a + Time.deltaTime);
            yield return null;
        }

        action?.Invoke();

        yield break;
    }

    public IEnumerator FadeOutWhite(Action action)
    {
        if (_fadeInOutImage == null)
        {
            _fadeInOutImage = GameObject.FindGameObjectWithTag("FadeInOutImage").GetComponent<Image>();

            if (_fadeInOutImage == null)
            {
                yield break;
            }
        }

        _fadeInOutImage.gameObject.SetActive(true);
        _fadeInOutImage.color = new Color(1, 1, 1, 1);

        while (_fadeInOutImage.color.a > 0)
        {
            _fadeInOutImage.color = new Color(1, 1, 1, _fadeInOutImage.color.a - Time.deltaTime);
            yield return null;
        }

        action?.Invoke();
        _fadeInOutImage.gameObject.SetActive(false);

        yield break;
    }
}
