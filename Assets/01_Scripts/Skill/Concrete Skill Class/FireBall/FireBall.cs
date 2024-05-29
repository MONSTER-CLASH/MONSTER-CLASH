using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private FireBallCardData _fireBallCardData;
    private float _damage;
    private float _destroyTime;

    private void Awake()
    {
        _damage = _fireBallCardData.Damage;
        _destroyTime = _fireBallCardData.DestroyTime;

        Collider[] enemys = Physics.OverlapSphere(transform.position, 5, 1 << LayerMask.NameToLayer("Enemy"));

        foreach(Collider enemy in enemys)
        {
            if (enemy.GetComponent<HealthSystem>() != null)
            {
                enemy.GetComponent<HealthSystem>().TakeDamage(_damage, gameObject);
            }
        }

        Destroy(gameObject, _destroyTime);
    }
}
