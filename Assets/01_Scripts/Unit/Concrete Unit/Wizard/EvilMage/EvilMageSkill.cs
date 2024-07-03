using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMageSkill : MonoBehaviour
{
    private GameObject _attacker;
    [SerializeField] private GameObject _splashVFX;
    private string _enemyLayer;
    private float _hitDamage;
    private float _splashDamage;
    private float _stunTime;
    private float _speed;

    private void Awake()
    {
        Destroy(gameObject, 3);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void SetEvilMageSkillData(GameObject attacker, string enemyLayer, float hitDamage, float splashDamage, float stunTime, float speed)
    {
        _attacker = attacker;
        _enemyLayer = enemyLayer;
        _hitDamage = hitDamage;
        _splashDamage = splashDamage;
        _stunTime = stunTime;
        _speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthSystem>() && other.gameObject.layer == LayerMask.NameToLayer(_enemyLayer))
        {
            Collider hit = other;
            hit.GetComponent<HealthSystem>().TakeDamage(_hitDamage, _attacker);

            Collider[] enemys = Physics.OverlapSphere(transform.position, 2.5f, 1 << LayerMask.NameToLayer(_enemyLayer));

            foreach(Collider enemy in enemys)
            {
                if (enemy != hit)
                {
                    enemy.GetComponent<HealthSystem>()?.TakeDamage(_splashDamage, _attacker);
                }
            }

            foreach (Collider enemy in enemys)
            {
                enemy.GetComponent<BuffSystem>()?.AddBuff(new StunBuff(_stunTime));
            }

            Instantiate(_splashVFX, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
