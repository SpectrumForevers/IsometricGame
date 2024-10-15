using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField] float barrelHealth = 10f;
    [SerializeField] float damageFromExplosive = 100f;
    [SerializeField] float rangeForDealDamage = 20f;
    [SerializeField] GameObject explosiveVFX;

    private void Update()
    {
        if (barrelHealth <= 0)
        {
            StartExplosive();
        }
    }

    private void StartExplosive()
    {
        StartCoroutine(Explosive());
    }
    IEnumerator Explosive()
    {
        Instantiate(explosiveVFX, transform.position, Quaternion.identity);
        List<GameObject> listEnemy = new List<GameObject>();
        listEnemy = GameManager.Instance.GetListEnemy();
        foreach (GameObject enemy in listEnemy)
        {
            if (Vector3.Distance(gameObject.transform.position, enemy.transform.position) <= rangeForDealDamage)
            {
                enemy.GetComponent<Enemy>().SetDamage(damageFromExplosive);
            }
        }
        GameObject player = GameManager.Instance.GetPlayer();
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= rangeForDealDamage)
        {
            player.GetComponent<Player>().SetDamage(damageFromExplosive);
        }

        Destroy(gameObject);
        yield return null;
    }
    public void SetDamage(float damage)
    {
        barrelHealth -= damage;
    }
}
