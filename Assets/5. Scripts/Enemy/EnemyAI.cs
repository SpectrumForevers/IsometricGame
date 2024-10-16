using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] GameObject player;
    
    private void Update()
    {
        if (player == null)
        {
            player = GameManager.Instance.GetPlayer();
        }
        agent.SetDestination(player.transform.position);
    }
}
