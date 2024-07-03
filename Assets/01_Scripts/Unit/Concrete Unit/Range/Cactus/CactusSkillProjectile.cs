using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSkillProjectile : MonoBehaviour
{
    private GameObject _attacker;
    private string _enemyLayer;
    private float _firstHitDamage;
    private float _laterHitDamage;
    private float _speed;
    private bool isFirstHitted;

    private void Awake()
    {
        Destroy(gameObject, 1.25f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void SetCactusSkillData(GameObject attacker, string enemyLayer, float firstHitDamage, float laterHitDamage, float speed)
    {
        _attacker = attacker;
        _enemyLayer = enemyLayer;
        _firstHitDamage = firstHitDamage;
        _laterHitDamage = laterHitDamage;
        _speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthSystem>() && other.gameObject.layer == LayerMask.NameToLayer(_enemyLayer))
        {
            Collider hit = other;
            hit.GetComponent<HealthSystem>().TakeDamage(isFirstHitted ? _laterHitDamage : _firstHitDamage, _attacker);
            isFirstHitted = true;
            VFXManager.Instance.InstantiateUnitHitVFX(other.transform);
        }
    }
}
