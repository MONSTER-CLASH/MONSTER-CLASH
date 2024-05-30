using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArea : MonoBehaviour
{
    [SerializeField] private FireAreaCardData _fireAreaCardData;
    private float _damage;
    private float _tickTime;
    private float _destoryTime;

    private void Awake()
    {
        _damage = _fireAreaCardData.Damage;
        _tickTime = _fireAreaCardData.TickTime;
        _destoryTime = _fireAreaCardData.DurationTime;

        StartCoroutine(FireAreaCoroutine());
        Destroy(gameObject, _destoryTime);
    }

    private IEnumerator FireAreaCoroutine()
    {
        while (true)
        {
            Collider[] enemys = Physics.OverlapSphere(transform.position, 2.5f, 1 << LayerMask.NameToLayer("Enemy"));

            foreach (Collider enemy in enemys)
            {
                if (enemy.GetComponent<HealthSystem>() != null)
                {
                    enemy.GetComponent<HealthSystem>().TakeDamage(_damage, gameObject);
                }
            }

            yield return new WaitForSeconds(_tickTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.5f, 0, 0, 0.15f);
        Gizmos.DrawSphere(transform.position, 2.5f);
    }
}
