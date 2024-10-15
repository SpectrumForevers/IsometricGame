using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;

    public void SetDamagePerBullet(float damage)
    {
        this.damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.enemy)
        {
            other.GetComponent<Enemy>().SetDamage(damage);
            Destroy(gameObject);
        }
        if (other.tag == Tags.barrelExplosive)
        {
            other.GetComponent<ExplosiveBarrel>().SetDamage(damage);
            Destroy(gameObject);
        }
    }
}
