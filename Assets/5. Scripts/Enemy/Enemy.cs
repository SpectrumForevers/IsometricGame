using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemyHealth = 50f;
    [SerializeField] float damageDeal = 5f;

    [SerializeField] Animator animator;

    Coroutine attackCorutine;
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
            //other.gameObject.GetComponent<Player>().SetDamage(damageDeal);
        }
    }
    public void StartAttackEnemy(GameObject player)
    {
        if (attackCorutine == null)
        {
            ActivateAttack();
        
            attackCorutine = StartCoroutine(AttackPlayer(player));
        }
        
    }
    public void StopAttackEnemy()
    {
        if (attackCorutine != null)
        {
            DeactivateAttack();
            StopCoroutine(attackCorutine);
            attackCorutine = null;
        }
    }
    IEnumerator AttackPlayer(GameObject player)
    {
        //AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(1);
        float currentTime = 2.5f;
        //Debug.Log(currentTime);
        while (true)
        {
            Debug.Log("hit");
            yield return new WaitForSeconds(currentTime);
            player.GetComponent<Player>().SetDamage(damageDeal);
        }
    }

    public void ActivateAttack()
    {
        animator.SetBool("Attack", true);
        animator.SetLayerWeight(1, 1);
        
    }
    public void DeactivateAttack()
    {
        animator.SetBool("Attack", false);
        animator.SetLayerWeight(1, 0);
    }
}
