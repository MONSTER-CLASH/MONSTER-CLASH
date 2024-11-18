using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimation : MonoBehaviour
{
    [SerializeField] private int _moveTime;
    [SerializeField] private float _moveSpeed;

    private bool _isLeft;

    private void Awake()
    {
        StartCoroutine(ArrowAnimationCoroutine());
    }

    private IEnumerator ArrowAnimationCoroutine()
    {
        while (true)
        {
            if (_isLeft)
            {
                for (int i=0; i<_moveTime; i++)
                {
                    transform.Translate(Vector3.right * _moveSpeed);
                    yield return null;
                }
                _isLeft = false;
            }
            else
            {
                for (int i = 0; i < _moveTime; i++)
                {
                    transform.Translate(Vector3.left * _moveSpeed);
                    yield return null;
                }
                _isLeft = true;
            }
        }
    }
}
