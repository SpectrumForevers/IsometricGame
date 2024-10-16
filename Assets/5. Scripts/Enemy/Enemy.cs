using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyHealth = 50f;
    [SerializeField] float damageDeal = 5f;
    private void Start()
    {
        GameManager.Instance.SetNewEnemyActive(gameObject);
    }
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tags.player)
        {
            other.gameObject.GetComponent<Player>().SetDamage(damageDeal);
        }
    }
}
