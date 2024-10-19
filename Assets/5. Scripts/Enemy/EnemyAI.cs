using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject player;
    [SerializeField] Enemy enemy;
    [SerializeField] float attackRange = 2f;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.GetPlayer();
        }
        
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < attackRange)
        {
            enemy.StartAttackEnemy(player);
            agent.SetDestination(gameObject.transform.position);
        }
        else
        {
            enemy.StopAttackEnemy();
            agent.SetDestination(player.transform.position);
        }
    }
}
