using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill : MonoBehaviour
{
    private Collider _collider;
    private float _tickDamage;
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

    public void SetDragonSkillData(float tickDamage, string enemyLayer, GameObject dragon)
    {
        _tickDamage = tickDamage;
        _enemyLayer = enemyLayer;
        _dragon = dragon;

        StartCoroutine(DragonSkillCoroutine());
    }

    private IEnumerator DragonSkillCoroutine()
    {
        for (int i=0; i<10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            _collider.enabled = true;
            yield return new WaitForSeconds(0.01f);
            _collider.enabled = false;
        }

        Destroy(gameObject);

        yield break;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(_enemyLayer))
        {
            other.GetComponent<HealthSystem>().TakeDamage(_tickDamage, gameObject);
        }
    }
}
