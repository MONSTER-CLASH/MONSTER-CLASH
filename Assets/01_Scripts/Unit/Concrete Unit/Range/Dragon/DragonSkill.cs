using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill : MonoBehaviour
{
    private Collider _collider;
    private float _curDamage;
    private float _firstDamage;
    private float _secondDamage;
    private float _thirdDamage;
    private string _enemyLayer;
    private GameObject _dragon;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }

    private void Update()
    {
        if (_dragon == null) Destroy(gameObject);
    }

    public void SetDragonSkillData(float firstDamage, float secondDamage, float thirdDamage, string enemyLayer, GameObject dragon)
    {
        _firstDamage = firstDamage;
        _secondDamage = secondDamage;
        _thirdDamage = thirdDamage;
        _enemyLayer = enemyLayer;
        _dragon = dragon;

        StartCoroutine(DragonSkillCoroutine());
    }

    private IEnumerator DragonSkillCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        _curDamage = _firstDamage;
        _collider.enabled = true;
        yield return new WaitForSeconds(0.01f);
        _collider.enabled = false;

        yield return new WaitForSeconds(0.3f);
        _curDamage = _secondDamage;
        _collider.enabled = true;
        yield return new WaitForSeconds(0.01f);
        _collider.enabled = false;

        yield return new WaitForSeconds(0.4f);
        _curDamage = _thirdDamage;
        _collider.enabled = true;
        yield return new WaitForSeconds(0.01f);
        _collider.enabled = false;

        Destroy(gameObject);

        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(_enemyLayer))
        {
            other.GetComponent<HealthSystem>().TakeDamage(_curDamage, gameObject);
        }
    }
}
