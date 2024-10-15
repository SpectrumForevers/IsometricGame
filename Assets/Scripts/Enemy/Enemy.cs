using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyHealth = 50f;
    private void Update()
    {
        if (enemyHealth <= 0)
        {
            GameManager.Instance.RemoveEnemyFromList(gameObject);
            Destroy(gameObject);
        }
    }
    public void SetDamage(float damage)
    {
        enemyHealth -= damage;
    }
}
